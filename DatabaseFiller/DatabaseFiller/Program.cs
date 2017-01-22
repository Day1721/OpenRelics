using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseFiller.DbClasses;
using Newtonsoft.Json;

namespace DatabaseFiller
{
    class Program
    {
        private static Relic MakeRelic(RelictInputViewModel model)
        {
            return new Relic
            {
                Id = model.id,
                Dating = model.dating_of_obj,
                Latitude = model.latitude,
                Longitude = model.longitude,
                Name = model.identification,
                RegisterNumber = model.register_number,
                State = model.state,
                PlaceId = model.place_id,
                PlaceName = model.place_name,
                CommuneName = model.commune_name,
                DistrictName = model.district_name,
                VoivodeshipName = model.voivodeship_name
            };
        }

        private static Tuple<List<Relic>, List<Connection>> GetDataFromInput(RelictInputViewModel model)
        {
            var relics = new List<Relic>
            {
                MakeRelic(model)
            };
            var connections = new List<Connection>();
            var res = Tuple.Create(relics, connections);
            model.descendants.Aggregate(res, (acc, submodel) =>
            {
                var tuple = GetDataFromInput(submodel);
                tuple.Item1.ForEach(acc.Item1.Add);
                tuple.Item2.ForEach(acc.Item2.Add);
                acc.Item2.Add(new Connection
                {
                    Ascendant = MakeRelic(model).Id,
                    Descendant = MakeRelic(submodel).Id
                });
                return acc;
            });
            return res;
        }

        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());
            string path = Console.ReadLine();
            string[] files;
            try
            {
                files = Directory.GetFiles(path);
            }
            catch
            {
                Console.WriteLine("Input path is invalid");
                return;
            }
            var parsed = new {Relics = new List<Relic>(), Connections = new List<Connection>()};
            Console.Write("Parcing files... ");
            using (var progress = new ProgressBar())
            { 
                int counter = 0;
                foreach (var file in files)
                {
                    string json = File.ReadAllText(file);
                    var data = JsonConvert.DeserializeObject<RelictInputViewModel>(json);
                    var tuple = GetDataFromInput(data);
                    tuple.Item1.ForEach(relic => parsed.Relics.Add(relic));
                    tuple.Item2.ForEach(connection =>
                    {
                        parsed.Connections.Add(connection);
                    });
                    counter++;
                    progress.Report((double) counter / files.Length);
                }
            }
            Console.Write("\nCreating database with data... ");
            using (var db = new RelicsDbContext())
            using (var progress = new ProgressBar())
            {
                int counter = 0;
                foreach (var relic in parsed.Relics)
                {
                    db.Relics.Add(relic);
                    counter++;
                    progress.Report((double) counter / (parsed.Relics.Count + parsed.Connections.Count));
                }

                foreach (var connection in parsed.Connections)
                {
                    db.Connections.Add(connection);
                    counter++;
                    progress.Report((double) counter / (parsed.Relics.Count + parsed.Connections.Count));
                }

                    Console.WriteLine("\nDone. {0} changes made.\n" +
                                  "Press any key to exit", db.SaveChanges());
            }
            Console.ReadKey();
        }
    }
}
