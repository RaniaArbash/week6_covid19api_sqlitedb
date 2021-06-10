using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CovidDetail.Models
{
    public class NetworkingManager
    {
        private string url = "https://api.covid19api.com";
         private HttpClient client = new HttpClient();


        public async Task<List<WorldData>> GetAllCountries()
        {
            //client.GetStringAsync

            var response = await client.GetAsync(url+"/summary/");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<WorldData>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();// json
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                var array = dic.ElementAt(3).Value;
                return JsonConvert.DeserializeObject<List<WorldData>>(array.ToString());

            }

        }

        //public async Task<int> getData()
        //{
        //    return 5;
        //}

        public async Task<Overview> GetOverview()
        {
            
            var response = await client.GetAsync(url+"/summary");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new Overview();
            else
            {
                //json
                var stringResponse = await response.Content.ReadAsStringAsync();// huge json

                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                var array = dic.ElementAt(2).Value;
                return JsonConvert.DeserializeObject<Overview>(array.ToString());
            }

        }

        public async Task<IEnumerable<CountryData>> GetByCountry(string country)
        {
            var str = $"{url}/live/country/{country}";
            var response = await client.GetStringAsync(str);
            return JsonConvert.DeserializeObject<List<CountryData>>(response);

        }


    }
}
