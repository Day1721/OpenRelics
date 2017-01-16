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

        public List<int> GetDirectDescendants(int id)
        {
            var res =
                from connection in _db.Connections
                where connection.Ascendant == id
                select connection.Descendant;

            return res.ToList();
        }

        public List<int> GetAllDescendants(int id)
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
            return res;
        }

        public IQueryable<int> GetAllFromRegion(LocationViewModel model)
        {
            if (string.IsNullOrEmpty(model.DistrictName))
                return 
                    from relic in _db.Relics
                    where relic.VoivodeshipName == model.VoivodeshipName
                    select relic.Id;

            if (string.IsNullOrEmpty(model.CommuneName))
                return 
                    from relic in _db.Relics
                    where relic.VoivodeshipName == model.VoivodeshipName
                          && relic.DistrictName == model.DistrictName
                    select relic.Id;

            if (string.IsNullOrEmpty(model.PlaceName))
                return
                    from relic in _db.Relics
                    where relic.VoivodeshipName == model.VoivodeshipName
                          && relic.DistrictName == model.DistrictName
                          && relic.CommuneName == model.CommuneName
                    select relic.Id;

            return 
                from relic in _db.Relics
                where relic.VoivodeshipName == model.VoivodeshipName
                      && relic.DistrictName == model.DistrictName
                      && relic.CommuneName == model.CommuneName
                      && relic.PlaceName == model.PlaceName
                select relic.Id;
        }
    }
}