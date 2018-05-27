using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FreelanceHuntApi.Model
{
    public class ProjectDetail
    {
        public int ProjectId { get; private set; }

        public string Url { get; private set; }

        public string UrlApi { get; private set; }

        public From From { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string DescriptionHTML { get; private set; }

        public int StatusId { get; private set; }

        public string StatusName { get; private set; }

        public int BidCount { get; private set; }

        public int HasPlacedBid { get; private set; }

        public DateTime PublicationTime { get; private set; }

        public DateTime ExpireTime { get; private set; }

        public List<string> Skills { get; private set; }

        public List<PaymentType> PaymentTypes { get; private set; }

        public List<string> Tags { get; private set; }

        public List<Attachment> Attachments { get; private set; }

        private static List<string> TagsFromJson(string json)
        {
            if (json == null) return new List<string>();
            var tags = new List<string>();
            JArray jArray = JArray.Parse(json);
            foreach (var tag in jArray)
            {
                tags.Add(tag.Value<string>());
            }
            return tags;
        }

        public static ProjectDetail ProjectDetailsFromJson(string response)
        {
            JObject jObject = JObject.Parse(response);
            return new ProjectDetail
            {
                ProjectId = jObject["project_id"].ToObject<int>(),
                Url = jObject["url"].ToObject<string>(),
                UrlApi = jObject["url_api"].ToObject<string>(),
                From = Model.From.FromJson(jObject["from"].ToString()),
                Name = jObject["name"].ToObject<string>(),
                Description = jObject["description"].ToObject<string>(),
                DescriptionHTML = jObject["description_html"].ToObject<string>(),
                StatusId = jObject["status_id"].ToObject<int>(),
                StatusName = jObject["status_name"].ToObject<string>(),
                BidCount = jObject["bid_count"].ToObject<int>(),
                HasPlacedBid = jObject["has_placed_bid"].ToObject<int>(),
                PublicationTime = jObject["publication_time"].ToObject<DateTime>(),
                ExpireTime = jObject["expire_time"].ToObject<DateTime>(),
                Skills = Skill.SkillsFromJson(jObject["skills"].ToString()),
                Attachments = Attachment.AttachmentsFromJson(jObject["attachments"]?.ToString()),
                PaymentTypes = PaymentType.FromJson(jObject["payment_types"]?.ToString()),
                Tags = TagsFromJson(jObject["tags"]?.ToString())
            };
            
        }
    }
}
