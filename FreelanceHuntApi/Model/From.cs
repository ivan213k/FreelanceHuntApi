using Newtonsoft.Json.Linq;

namespace FreelanceHuntApi.Model
{
    public class From
    {
      
        public string Avatar { get; private set; }

        public string AvatarMd { get; private set; }

        public string Login { get; private set; }

        public string FirstName { get; private set; }

        public string Surname { get; private set; }

        public string ProfileId { get; private set; }

        public string Url { get; private set; }

        internal static From FromJson(string jsonResponse)
        {
            JObject jObject = JObject.Parse(jsonResponse);
            return new From
            {
                Avatar =    jObject["avatar"].ToObject<string>(),
                Login =     jObject["login"].ToObject<string>(),
                FirstName = jObject["fname"]?.ToObject<string>(),
                Surname =   jObject["sname"]?.ToObject<string>(),
                ProfileId = jObject["profile_id"].ToObject<string>(),
                Url =       jObject["url"].ToObject<string>()
            };
        }
    }
}
