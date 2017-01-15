using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenRelicsWebApp.Models;

namespace OpenRelicsWebApp.Controllers
{
    [RoutePrefix("api/relics")]
    public class RelicsApiController : ApiController
    {
        private readonly RelicsDbContext db = new RelicsDbContext();

        //GET: api/relics/queries
        [HttpGet, Route("queries")]
        public IHttpActionResult GetQueries() => Ok(RelicsController.Queries);

        //GET: api/relics/get-by-id/{id}
        [HttpGet, Route("get-by-id/{id}")]
        public IHttpActionResult GetDataById(int id)
        {
            var res =
                from relic in db.Relics
                where relic.Id == id
                select relic;

            if (!res.Any()) return BadRequest("There is no relic with given id");

            return Ok(res.First());
        }

        //GET: api/relics/get-direct-descendants/{id}
        [HttpGet, Route("get-direct-descendants")]
        public IHttpActionResult GetDirectDescendants(int id)
        {
            var check =
                from relic in db.Relics
                where relic.Id == id
                select relic;

            if (!check.Any()) return BadRequest("There is no relic with given id");

            return Ok(
                from connection in db.Connections
                where connection.Ascendant == id
                select connection.Descendant);
        }

        //GET: api/relics/get-all-descendants/{id}
        [HttpGet, Route("get-all-descendants")]
        public IHttpActionResult GetAllDescendants(int id)
        {
            var check =
                from relic in db.Relics
                where relic.Id == id
                select relic;

            if (!check.Any()) return BadRequest("There is no relic with given id");

            var res = new List<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(id);
            while (!queue.Any())
            {
                int subid = queue.Dequeue();
                var descendants = 
                    from connection in db.Connections
                    where connection.Ascendant == id
                    select connection.Descendant;
                foreach (var descendant in descendants)
                {
                    res.Add(descendant);
                    queue.Enqueue(descendant);
                }
            }
            return Ok(res);
        }
    }
}