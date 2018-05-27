using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FreelanceHuntApi.Model
{
    public  class Feed
    {
        public From From { get; private set; }

        public DateTime Time { get; private set; }

        public string Message { get; private set; }

        public string  ProjectUrl {
            get
            {
                return Regex.Match(Message, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?").Value;
            }
        }

        public bool IsNew { get; private set; }

        public int?  ProjectId { get; private set; }

        public bool IsProject { get; private set; }


        private static Feed FromJson(string json)
        {
            JObject jObject = JObject.Parse(json);
            int? projectid = null;
            bool isProject = false;
            if(jObject["related"] != null)
            {
                JObject related = JObject.Parse(jObject["related"].ToString());
                projectid = related["project_id"].ToObject<int>();
                isProject = true;
            }


            return new Feed
            {
                From = Model.From.FromJson(jObject["from"].ToString()),
                Time = jObject["time"].ToObject<DateTime>(),
                Message = Regex.Replace(jObject["message"].ToObject<string>(), "<[^>]+>", string.Empty),
                IsNew = jObject["is_new"].ToObject<bool>(),
                ProjectId = projectid,
                IsProject = isProject
            };
        }

        public static List<Feed> FeedsFromJson(string response)
        {
            JArray jArray = JArray.Parse(response);
            var feeds = new List<Feed>();
            foreach (var feed in jArray)
            {
                feeds.Add(FromJson(feed.ToString()));
            }
            return feeds;
        }
    }
}
