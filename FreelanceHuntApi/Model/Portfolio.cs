using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FreelanceHuntApi.Model
{
    public class Portfolio
    {
        public string AvatarUrl { get; private set; }

        public string AvatarMd { get; private set; }

        public string CityName_RU { get; private set; }

        public string CountryName_RU { get; private set; }

        public DateTime CreationDate { get; private set; }

        public string FirstName { get; private set; }

        public bool IsEmployer { get; private set; }

        public bool IsFreelancer { get; private set; }

        public bool IsOnline { get; private set; }

        public bool IsPlusActivity { get; private set; }

        public DateTime LastActivity { get; private set; }

        public string  Resume { get; private set; }

        public string ResumeHTML { get; private set; }

        public string Login { get; private set; }

        public int NegativeReviews { get; private set; }

        public int PositiveReviews { get; private set; }

        public int  Rating { get; private set; }

        public int RatingPosition { get; private set; }

        public int RatingPositionCategory { get; private set; }

        public int RatingPositionCategoryAlt { get; private set; }

        public string SkillNameAlt { get; private set; }

        public string SkillName { get; private set; }

        public string  Surname { get; private set; }

        public List<Snippet> Snipetts { get; private set; }

        public string StatusName { get; private set; }

        public int ProfileId { get; private set; }

        public string Url { get; private set; }

        public string UrlPrivatMessage { get; private set; }

        public string Website { get; private set; }

        internal static Portfolio FromJson(string response)
        {
            JObject jObject = JObject.Parse(response);
            return new Portfolio
            {
                AvatarUrl = jObject["avatar"].ToObject<string>(),
                AvatarMd = jObject["avatar_md"].ToObject<string>(),
                CityName_RU = jObject["city_name_ru"].ToObject<string>(),
                CountryName_RU = jObject["country_name_ru"].ToObject<string>(),
                CreationDate = jObject["creation_date"].ToObject<DateTime>(),
                FirstName = jObject["fname"].ToObject<string>(),
                IsEmployer = jObject["is_employer"].ToObject<bool>(),
                IsFreelancer = jObject["is_freelancer"].ToObject<bool>(),
                IsOnline = jObject["is_online"].ToObject<bool>(),
                IsPlusActivity = jObject["is_plus_active"].ToObject<bool>(),
                LastActivity = jObject["last_activity"].ToObject<DateTime>(),
                Resume = jObject["cv"].ToObject<string>(),
                ResumeHTML = jObject["cv_html"].ToObject<string>(),
                Login = jObject["login"].ToObject<string>(),
                NegativeReviews = jObject["negative_reviews"].ToObject<int>(),
                PositiveReviews = jObject["positive_reviews"].ToObject<int>(),
                ProfileId = jObject["profile_id"].ToObject<int>(),
                Rating = jObject["rating"].ToObject<int>(),
                RatingPosition = jObject["rating_position"].ToObject<int>(),
                RatingPositionCategory = jObject["rating_position_category"].ToObject<int>(),
                RatingPositionCategoryAlt = jObject["rating_position_category_alt"].ToObject<int>(),
                SkillName = jObject["skill_name"].ToObject<string>(),
                SkillNameAlt = jObject["skill_name_alt"].ToObject<string>(),
                StatusName = jObject["status_name"].ToObject<string>(),
                Surname = jObject["sname"].ToObject<string>(),
                Url = jObject["url"].ToObject<string>(),
                UrlPrivatMessage = jObject["url_private_message"].ToObject<string>(),
                Website = jObject["website"].ToObject<string>(),
                Snipetts = Snippet.SnippetsFromJson(jObject["snippets"].ToString())

            };
        }
    }
}
