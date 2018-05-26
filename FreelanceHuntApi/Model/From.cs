using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceHuntApi.Model
{
    public class From
    {
      
        public string Avatar { get; set; }

        public string AvatarMd { get; set; }

        public string Login { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string ProfileId { get; set; }

        public string Url { get; set; }

        public static From FromJson(string jsonResponse)
        {
            JObject jObject = JObject.Parse(jsonResponse);
            return new From
            {
                Avatar = jObject["avatar"].ToObject<string>(),
                Login = jObject["login"].ToObject<string>(),
                FirstName = jObject["fname"].ToObject<string>(),
                Surname = jObject["sname"].ToObject<string>(),
                ProfileId = jObject["profile_id"].ToObject<string>(),
                Url = jObject["url"].ToObject<string>()
            };
        }
    }
}
