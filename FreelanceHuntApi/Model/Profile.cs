using Newtonsoft.Json.Linq;
using System;

namespace FreelanceHuntApi.Model
{
    public class Profile
    {

        public string ProfileId { get; set; }


        public string UrlAdress { get; set; }


        public string UrlForPrivateMessage { get; set; }


        public string Avatar { get; set; }


        public bool IsFreelancer { get; set; }


        public bool IsEmployer { get; set; }


        public string Login { get; set; }


        public string FirstName { get; set; }


        public string Surname { get; set; }


        public DateTime? BirthDate { get; set; }


        public string Rating { get; set; }


        public string RatingPosition { get; set; }


        public string CountryName_ru { get; set; }


        public string CityName_ru { get; set; }


        public DateTime CreationDate { get; set; }


        public string PositiveReviews { get; set; }


        public string NegativeReviews { get; set; }


        public string IsPhoneVerified { get; set; }


        public string IsFirstNameVerified { get; set; }


        public string IsBirthDateVerified { get; set; }


        public string IsWmidVerified { get; set; }


        public string IsOkpayVerified { get; set; }


        public string IsEmailVerified { get; set; }

        
        public bool IsOnline { get; set; }


        public DateTime LastActivity { get; set; }


        public string Website { get; set; }


        public string StatusName { get; set; }


        public string SkillName { get; set; }


        public string SkillAltName { get; set; }


        public string RatingPositionCategory { get; set; }


        public string RatingPositionCategoryAlt { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }


        public string Skype { get; set; }


        public string Wmid { get; set; }


        public string YandexMoney { get; set; }


        public string Resume { get; set; }

        public string ResumeHtml { get; set; }

        
        public static Profile FromJson(string jsonResponse)
        {
            JObject jObject = JObject.Parse(jsonResponse);
            return new Profile
            {
                ProfileId =             jObject["profile_id"].ToObject<string>(),
                UrlAdress =             jObject["url"].ToObject<string>(),
                UrlForPrivateMessage =  jObject["url_private_message"].ToObject<string>(),
                Avatar =                jObject["avatar"].ToObject<string>(),
                IsFreelancer =          jObject["is_freelancer"].ToObject<bool>(),
                IsEmployer =            jObject["is_employer"].ToObject<bool>(),
                Login =                 jObject["login"].ToObject<string>(),
                FirstName =             jObject["fname"].ToObject<string>(),
                Surname =               jObject["sname"].ToObject<string>(),
                BirthDate =             jObject["birth_date"].ToObject<DateTime?>(),
                Rating =                jObject["rating"].ToObject<string>(),
                RatingPosition =        jObject["rating_position"].ToObject<string>(),
                CountryName_ru =        jObject["country_name_ru"].ToObject<string>(),
                CityName_ru =           jObject["city_name_ru"].ToObject<string>(),
                CreationDate =          jObject["creation_date"].ToObject<DateTime>(),
                PositiveReviews =       jObject["positive_reviews"].ToObject<string>(),
                NegativeReviews =       jObject["negative_reviews"].ToObject<string>(),
                IsPhoneVerified =       jObject["is_phone_verified"].ToObject<string>(),
                IsFirstNameVerified =   jObject["is_fname_verified"].ToObject<string>(),
                IsBirthDateVerified =   jObject["is_birth_date_verified"].ToObject<string>(),
                IsWmidVerified =        jObject["is_wmid_verified"].ToObject<string>(),
                IsOkpayVerified =       jObject["is_okpay_verified"].ToObject<string>(),
                IsEmailVerified =       jObject["is_email_verified"].ToObject<string>(),
                IsOnline =              jObject["is_online"].ToObject<bool>(),
                LastActivity =          jObject["last_activity"].ToObject<DateTime>(),
                Website =               jObject["website"].ToObject<string>(),
                StatusName =            jObject["status_name"].ToObject<string>(),
                SkillName =             jObject["skill_name"].ToObject<string>(),
                SkillAltName =          jObject["skill_name_alt"].ToObject<string>(),
                RatingPositionCategory = jObject["rating_position_category"].ToObject<string>(),
                RatingPositionCategoryAlt = jObject["rating_position_category_alt"].ToObject<string>(),
                Email =                 jObject["email"].ToObject<string>(),
                Phone =                 jObject["phone"].ToObject<string>(),
                Skype =                 jObject["skype"].ToObject<string>(),
                Wmid =                  jObject["wmid"].ToObject<string>(),
                YandexMoney =           jObject["yandex_money"].ToObject<string>(),
                Resume =                jObject["cv"].ToObject<string>(),
                ResumeHtml =            jObject["cv_html"].ToObject<string>()
            };
        }
        
    }
}
