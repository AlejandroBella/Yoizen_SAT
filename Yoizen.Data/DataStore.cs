using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoizen.Data.Entities;

namespace Yoizen.Data
{
    public class DataStore
    {
        public DataStore()
        {
            LoadPersonajes();
        }


        private List<Personaje> personajes;
        public List<Personaje> Personajes
        {
            get
            {              
               return personajes;
            }
        }
        protected virtual void LoadPersonajes()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://apisimpsons.fly.dev/api/personajes?limit=700");
            var result = client.GetAsync(client.BaseAddress).Result;
            var resultList = JObject.Parse(result.Content.ReadAsStringAsync().Result);

            personajes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Personaje>>(resultList["docs"].ToString());



        }
    }
}
