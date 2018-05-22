using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FreelanceHuntApi.Model
{
    public class Message
    {
        public string Url { get; set; }

        public From From { get; set; }

        public From To { get; set; }

        public string TextHTML { get; set; }

        public string Text
        {
            get {return Regex.Replace(TextHTML, "<[^>]+>", string.Empty); } 
           
        }
        public DateTime? PostTime { get; set; }

        private static Message FromJson(string response)
        {
            JObject item = JObject.Parse(response);
            return new Message
            {
                Url = item["url"].ToObject<string>(),
                From = Model.From.FromJson(item["from"].ToString()),
                To = Model.From.FromJson(item["to"].ToString()),
                TextHTML = item["message_html"].ToObject<string>(),
                PostTime = item["post_time"].ToObject<DateTime?>()
            };
        }

        public static List<Message> MessageListFromJson(string json)
        {
            var messageList = new List<Message>();

            JsonReader jsonReader = new JsonTextReader(new StringReader(json));

            JToken jToken = JObject.ReadFrom(jsonReader);

            foreach (var item in jToken.Children())
            {
                messageList.Add(Message.FromJson(item.ToString()));
            }

            return messageList;  
        }
    }
}
