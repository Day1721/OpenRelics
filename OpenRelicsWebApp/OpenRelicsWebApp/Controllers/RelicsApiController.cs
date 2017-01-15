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
        //private readonly RelicsDbContext db = new RelicsDbContext();
        private readonly DbAccessor _accessor = new DbAccessor();

        //GET: api/relics/queries
        [HttpGet, Route("queries")]
        public IHttpActionResult GetQueries() => Ok(RelicsController.Queries);

        //GET: api/relics/get-by-id/{id}
        [HttpGet, Route("get-by-id/{id}")]
        public IHttpActionResult GetDataById(int id)
        {
            var res = _accessor.GetById(id);
            if (res == null)
                return BadRequest("There is no relic with given id");

            return Ok(res);
        }

        //GET: api/relics/get-direct-descendants/{id}
        [HttpGet, Route("get-direct-descendants")]
        public IHttpActionResult GetDirectDescendants(int id)
        {
            var check = _accessor.GetById(id);

            if (check == null) return BadRequest("There is no relic with given id");

            return Ok(_accessor.GetDirectDescendants(id));

        }

        //GET: api/relics/get-all-descendants/{id}
        [HttpGet, Route("get-all-descendants")]
        public IHttpActionResult GetAllDescendants(int id)
        {
            var check = _accessor.GetById(id);

            if (check == null) return BadRequest("There is no relic with given id");

            
            return Ok(_accessor.GetAllDescendants(id));
        }

        //GET: api/relics/all-from-region
        [HttpGet, Route("get-all-from-region")]
        public IHttpActionResult GetAllFromRegion([FromUri]LocationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_accessor.GetAllFromRegion(model));
        }
    }
}