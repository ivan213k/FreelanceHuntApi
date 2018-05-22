using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceHuntApi.Model
{
    public class Correspondence
    {
        public string MessageId { get; set; }

        public string Subject { get; set; }

        public string Url { get; set; }

        public string UrlApi { get; set; }

        public From From { get; set; }

        public string HasAttach { get; set; }

        public DateTime LastPostTime { get; set; }

        public DateTime FirstPostTime { get; set; }

        public int MessageCount { get; set; }

        public bool? IsUnread { get; set; }

        public static Correspondence CorrespondenceFromJson(string jsonResponse)
        {
            JObject item = JObject.Parse(jsonResponse);
            return new Correspondence
            {
                MessageId =     item["thread_id"].ToObject<string>(),
                Subject =       item["subject"].ToObject<string>(),
                Url =           item["url"].ToObject<string>(),
                UrlApi =        item["url_api"].ToObject<string>(),
                HasAttach =     item["has_attach"].ToObject<string>(),
                LastPostTime =  item["last_post_time"].ToObject<DateTime>(),
                FirstPostTime = item["first_post_time"].ToObject<DateTime>(),
                MessageCount =  item["message_count"].ToObject<int>(),
                IsUnread =      item["is_unread"].ToObject<bool?>(),

                From = Model.From.FromJson(item["from"].ToString())
            };


        }

        public static List<Correspondence> ListCorrespondenceFromJson(string jsonResponse)
        {
            var сorrespondenceList = new List<Correspondence>();

            JsonReader jsonReader = new JsonTextReader(new StringReader(jsonResponse));

            JToken jToken = JObject.ReadFrom(jsonReader);

            foreach (var item in jToken.Children())
            {
                сorrespondenceList.Add(Correspondence.CorrespondenceFromJson(item.ToString()));
            }
            return сorrespondenceList;
        }
    }
}
