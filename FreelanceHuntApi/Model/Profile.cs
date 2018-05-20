using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace FreelanceHuntApi.Model
{
    public class Profile
    {
        [JsonProperty("profile_id")]
        public string ProfileId { get; set; }

        [JsonProperty("url")]
        public string UrlAdress { get; set; }

        [JsonProperty("url_private_message")]
        public string UrlForPrivateMessage { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("is_freelancer")]
        public bool IsFreelancer { get; set; }

        [JsonProperty("is_employer")]
        public bool IsEmployer { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("fname")]
        public string FirstName { get; set; }

        [JsonProperty("sname")]
        public string Surname { get; set; }

        [JsonProperty("birth_date")]
        public DateTime? BirthDate { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("rating_position")]
        public string RatingPosition { get; set; }

        [JsonProperty("country_name_ru")]
        public string CountryName_ru { get; set; }

        [JsonProperty("city_name_ru")]
        public string CityName_ru { get; set; }

        [JsonProperty("creation_date")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("positive_reviews")]
        public string PositiveReviews { get; set; }

        [JsonProperty("negative_reviews")]
        public string NegativeReviews { get; set; }

        [JsonProperty("is_phone_verified")]
        public string IsPhoneVerified { get; set; }

        [JsonProperty("is_fname_verified")]
        public string IsFirstNameVerified { get; set; }

        [JsonProperty("is_birth_date_verified")]
        public string IsBirthDateVerified { get; set; }

        [JsonProperty("is_wmid_verified")]
        public string IsWmidVerified { get; set; }

        [JsonProperty("is_okpay_verified")]
        public string IsOkpayVerified { get; set; }

        [JsonProperty("is_email_verified")]
        public string IsEmailVerified { get; set; }

        [JsonProperty("is_online")]
        public bool IsOnline { get; set; }

        [JsonProperty("last_activity")]
        public DateTime LastActivity { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

        [JsonProperty("skill_name")]
        public string SkillName { get; set; }

        [JsonProperty("skill_alt_name")]
        public string SkillAltName { get; set; }

        [JsonProperty("rating_position_category")]
        public string RatingPositionCategory { get; set; }

        [JsonProperty("rating_position_category_alt")]
        public string RatingPositionCategoryAlt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("skype")]
        public string Skype { get; set; }

        [JsonProperty("wmid")]
        public string Wmid { get; set; }

        [JsonProperty("yandex_money")]
        public string YandexMoney { get; set; }

        [JsonProperty("icq")]
        public string Icq { get; set; }

        
        public static Profile FromJson(string jsonResponse)
        {
            JObject jObject = JObject.Parse(jsonResponse);
            return new Profile
            {
                ProfileId = jObject["jsonResponse"].ToObject<string>(),
                UrlAdress = jObject["url"].ToObject<string>(),
                UrlForPrivateMessage = jObject["url_private_message"].ToObject<string>(),
                Avatar = jObject["avatar"].ToObject<string>(),
                IsFreelancer = jObject["is_freelancer"].ToObject<bool>(),
                IsEmployer = jObject["is_employer"].ToObject<bool>(),
                Login = jObject["login"].ToObject<string>(),
                FirstName = jObject["fname"].ToObject<string>(),
                Surname = jObject["sname"].ToObject<string>(),
                BirthDate = jObject["birth_date"].ToObject<DateTime>(),
                Rating = jObject["rating"].ToObject<string>(),
                RatingPosition = jObject["rating_position"].ToObject<string>(),
                CountryName_ru = jObject["country_name_ru"].ToObject<string>(),
                CityName_ru = jObject["city_name_ru"].ToObject<string>(),
                CreationDate = jObject["creation_date"].ToObject<DateTime>(),
                PositiveReviews = jObject["positive_reviews"].ToObject<string>(),
                NegativeReviews = jObject["negative_reviews"].ToObject<string>(),
                IsPhoneVerified = jObject["is_phone_verified"].ToObject<string>(),
                IsFirstNameVerified = jObject["is_fname_verified"].ToObject<string>(),
                IsBirthDateVerified = jObject["is_birth_date_verified"].ToObject<string>(),
                IsWmidVerified = jObject["is_wmid_verified"].ToObject<string>(),
                IsOkpayVerified = jObject["is_okpay_verified"].ToObject<string>(),
                IsEmailVerified = jObject["is_email_verified"].ToObject<string>(),
                IsOnline = jObject["is_online"].ToObject<bool>(),
                LastActivity = jObject["last_activity"].ToObject<DateTime>(),
                Website = jObject["website"].ToObject<string>(),
                StatusName = jObject["status_name"].ToObject<string>(),
                SkillName = jObject["skill_name"].ToObject<string>(),
                SkillAltName = jObject["skill_alt_name"].ToObject<string>(),
                RatingPositionCategory = jObject["rating_position_category"].ToObject<string>(),
                RatingPositionCategoryAlt = jObject["rating_position_category_alt"].ToObject<string>(),
                Email = jObject["email"].ToObject<string>(),
                Phone = jObject["phone"].ToObject<string>(),
                Skype = jObject["skype"].ToObject<string>(),
                Wmid = jObject["wmid"].ToObject<string>(),
                YandexMoney = jObject["yandex_money"].ToObject<string>(),
                Icq = jObject["icq"].ToObject<string>(),
            };
        }
        
    }
}
