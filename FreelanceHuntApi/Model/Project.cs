﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceHuntApi.Model
{
    class Project
    {
        public int ProjectId { get; private set; }

        public string Url { get; private set; }

        public string UrlApi { get; private set; }

        public From From { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string DescriptionHTML { get; private set; }

        public int  StatusId { get; private set; }

        public string StatusName { get; private set; }

        public int BidCount { get; private set; }

        public int  HasPlacedBid { get; private set; }

        public DateTime PublicationTime { get; private set; }

        public DateTime ExpireTime { get; private set; }

        public bool IsJob { get; private set; }

        public bool IsFeatured { get; private set; }

        public bool IsIdentityVerified { get; private set; }

        public Skill[] Skills { get; private set; }

        public Project FromJson(string response)
        {
            JObject jObject = JObject.Parse(response);
            return new Project
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
                IsJob = jObject["is_job"].ToObject<bool>(),
                IsFeatured = jObject["is_featured"].ToObject<bool>(),
                IsIdentityVerified = jObject["is_identity_verified"].ToObject<bool>(),
                

            };
        }
    }
}
