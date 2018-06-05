using Newtonsoft.Json.Linq;
using System;

namespace FreelanceHuntApi.Model
{
    public class Profile
    {

        public string ProfileId { get; private set; }


        public string UrlAdress { get; private set; }


        public string UrlForPrivateMessage { get; private set; }


        public string Avatar { get; private set; }


        public bool IsFreelancer { get; private set; }


        public bool IsEmployer { get; private set; }


        public string Login { get; private set; }


        public string FirstName { get; private set; }


        public string Surname { get; private set; }


        public DateTime? BirthDate { get; private set; }


        public string Rating { get; private set; }


        public string RatingPosition { get; private set; }


        public string CountryName_ru { get; private set; }


        public string CityName_ru { get; private set; }


        public DateTime CreationDate { get; private set; }


        public string PositiveReviews { get; private set; }


        public string NegativeReviews { get; private set; }


        public string IsPhoneVerified { get; private set; }


        public string IsFirstNameVerified { get; private set; }


        public string IsBirthDateVerified { get; private set; }


        public string IsWmidVerified { get; private set; }


        public string IsOkpayVerified { get; private set; }


        public string IsEmailVerified { get; private set; }

        
        public bool IsOnline { get; private set; }


        public DateTime LastActivity { get; private set; }


        public string Website { get; private set; }


        public string StatusName { get; private set; }


        public string SkillName { get; private set; }


        public string SkillAltName { get; private set; }


        public string RatingPositionCategory { get; private set; }


        public string RatingPositionCategoryAlt { get; private set; }


        public string Email { get; private set; }


        public string Phone { get; private set; }


        public string Skype { get; private set; }


        public string Wmid { get; private set; }


        public string YandexMoney { get; private set; }


        public string Resume { get; private set; }


        public string ResumeHtml { get; private set; }

        
        internal static Profile FromJson(string jsonResponse)
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
                IsPhoneVerified =       jObject["is_phone_verified"]?.ToObject<string>(),
                IsFirstNameVerified =   jObject["is_fname_verified"].ToObject<string>(),
                IsBirthDateVerified = jObject["is_birth_date_verified"].ToObject<string>(),
                IsWmidVerified = jObject["is_wmid_verified"].ToObject<string>(),
                IsOkpayVerified = jObject["is_okpay_verified"].ToObject<string>(),
                IsEmailVerified = jObject["is_email_verified"].ToObject<string>(),
                IsOnline = jObject["is_online"].ToObject<bool>(),
                LastActivity = jObject["last_activity"].ToObject<DateTime>(),
                Website = jObject["website"].ToObject<string>(),
                StatusName = jObject["status_name"].ToObject<string>(),
                SkillName = jObject["skill_name"].ToObject<string>(),
                SkillAltName = jObject["skill_name_alt"].ToObject<string>(),
                RatingPositionCategory = jObject["rating_position_category"]?.ToObject<string>(),
                RatingPositionCategoryAlt = jObject["rating_position_category_alt"]?.ToObject<string>(),
                Email = jObject["email"]?.ToObject<string>(),
                Phone = jObject["phone"]?.ToObject<string>(),
                Skype = jObject["skype"]?.ToObject<string>(),
                Wmid = jObject["wmid"]?.ToObject<string>(),
                YandexMoney = jObject["yandex_money"]?.ToObject<string>(),
                Resume = jObject["cv"]?.ToObject<string>(),
                ResumeHtml = jObject["cv_html"]?.ToObject<string>()
            };
        }
        
    }
}
