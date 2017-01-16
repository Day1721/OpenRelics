using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenRelicsWebApp.Models
{
    class DbAccessor
    {
        private readonly RelicsDbContext _db = new RelicsDbContext();

        public Relic GetById(int id)
        {
            var res =
                from relic in _db.Relics
                where relic.Id == id
                select relic;

            if (!res.Any()) return null;

            return res.First();
        }

        public IEnumerable<Relic> GetDirectDescendants(int id)
        {
            var res =
                from connection in _db.Connections
                where connection.Ascendant == id
                select connection.Descendant;

            return from relic in _db.Relics
                   where res.Contains(relic.Id)
                   select relic;
        }

        public IEnumerable<Relic> GetAllDescendants(int id)
        {
            var res = new List<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(id);
            while (!queue.Any())
            {
                int subid = queue.Dequeue();
                var descendants =
                    from connection in _db.Connections
                    where connection.Ascendant == subid
                    select connection.Descendant;
                foreach (var descendant in descendants)
                {
                    res.Add(descendant);
                    queue.Enqueue(descendant);
                }
            }
            return from relic in _db.Relics
                   where res.Contains(relic.Id)
                   select relic;

        }

        public IQueryable<Relic> GetAllFromRegion(LocationViewModel model)
        {
            if (string.IsNullOrEmpty(model.DistrictName))
                return 
                    from relic in _db.Relics
                    where relic.VoivodeshipName == model.VoivodeshipName
                    select relic;

            if (string.IsNullOrEmpty(model.CommuneName))
                return 
                    from relic in _db.Relics
                    where relic.VoivodeshipName == model.VoivodeshipName
                          && relic.DistrictName == model.DistrictName
                    select relic;

            if (string.IsNullOrEmpty(model.PlaceName))
                return
                    from relic in _db.Relics
                    where relic.VoivodeshipName == model.VoivodeshipName
                          && relic.DistrictName == model.DistrictName
                          && relic.CommuneName == model.CommuneName
                    select relic;

            return 
                from relic in _db.Relics
                where relic.VoivodeshipName == model.VoivodeshipName
                      && relic.DistrictName == model.DistrictName
                      && relic.CommuneName == model.CommuneName
                      && relic.PlaceName == model.PlaceName
                select relic;
        }
    }
}