using System;
using System.Collections.Generic;
using System.Text;

namespace CovidDetail.Models
{
    public class CountryData
    {
        public string ID { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public string Date { get; set; }
    }
}
