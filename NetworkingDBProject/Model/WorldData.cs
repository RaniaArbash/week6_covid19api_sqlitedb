using System;
using System.Collections.Generic;
using System.Text;

namespace CovidDetail.Models
{
    public class WorldData
    {
        public string ID { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalRecovered { get; set; }
        public string Date { get; set; }
    }
}
