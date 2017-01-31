using System.Collections.Generic;

namespace DatabaseFiller
{
    public class RelictInputViewModel
    {
        public int id { get; set; }

        public string nid_id { get; set; }

        public string identification { get; set; }

        public string common_name { get; set; }

        public string state { get; set; }

        public string register_number { get; set; }

        public string dating_of_obj { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }

        public string country_code { get; set; }

        public object fprovince { get; set; }

        public object fplace { get; set; }

        public List<RelictInputViewModel> descendants { get; set; }

        public int place_id { get; set; }

        public string place_name { get; set; }

        public string commune_name { get; set; }

        public string district_name { get; set; }

        public string voivodeship_name { get; set; }
    }
}