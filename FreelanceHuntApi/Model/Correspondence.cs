using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace FreelanceHuntApi.Model
{
    public class Correspondence
    {
        public string MessageId { get; private set; }

        public string Subject { get; private set; }

        public string Url { get; private set; }

        public string UrlApi { get; private set; }

        public From From { get; private set; }

        public string HasAttach { get; private set; }

        public DateTime LastPostTime { get; private set; }

        public DateTime FirstPostTime { get; private set; }

        public int MessageCount { get; private set; }

        public bool? IsUnread { get; private set; }

        internal static Correspondence CorrespondenceFromJson(string jsonResponse)
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

        internal static List<Correspondence> ListCorrespondenceFromJson(string jsonResponse)
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
