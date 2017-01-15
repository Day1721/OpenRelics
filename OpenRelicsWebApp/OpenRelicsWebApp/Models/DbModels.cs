using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenRelicsWebApp.Models
{
    class Relic
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string State { get; set; }
        public string RegisterNumber { get; set; }
        public string Dating { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string CommuneName { get; set; }
        public string DistrictName { get; set; }
        public string VoivodeshipName { get; set; }
    }

    class Connection
    {
        [Column(Order = 0), Key]
        public int Ascendant { get; set; }

        [Column(Order = 1), Key]
        public int Descendant { get; set; }
    }
}
