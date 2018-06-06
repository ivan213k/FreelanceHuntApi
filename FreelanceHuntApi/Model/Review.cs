using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FreelanceHuntApi.Model
{
    public class Review
    {

        /// <summary>
        ///  Середнє арфиметичне оцінок для цього відгуку(замовник, фрілансер)
        /// </summary>
        public double? GradeAverage { get; private set; }

        /// <summary>
        ///  Своєчасність оплати, відповідність зазначеним умовам (Замовник)
        /// </summary>
        public int? GradePay { get; private set; }

        /// <summary>
        ///  Чіткість і ясність поставленого завдання, наявність чіткого ТЗ (Замовник)
        /// </summary>
        public int? GradeDefinition { get; private set; }

        /// <summary>
        ///  Обґрунтованість та адекватність вимог до проекту (Замовник)
        /// </summary>
        public int? GradeRequirements { get; private set; }

        /// <summary>
        ///  Загальний рівень виконаної роботи, відсутність помилок, наявність документації (Фрілансер)
        /// </summary>
        public int? GradeQuality { get; private set; }

        /// <summary>
        ///  Ступінь відповідності отриманого результату вартості проекту (Фрілансер)
        /// </summary>
        public int? GradeCost { get; private set; }

        /// <summary>
        ///  Володіння технологіями, рівень спілкування з замовником (Фрілансер)
        /// </summary>
        public int? GradeProfessionalism { get; private set; }

        /// <summary>
        ///  Легкість виходу на контакт, доступність виконавця (Фрілансер)
        /// </summary>
        public int? GradeConnectivity { get; private set; }

        /// <summary>
        ///  Наскільки фрілансер дотримувався обумовлених термінів
        /// </summary>
        public int? GradeSchedule { get; private set; }

        /// <summary>
        ///  текст відгуку
        /// </summary>
        public string ReviewComment { get; private set; }

        /// <summary>
        ///  Дата залишення відгуку
        /// </summary>
        public DateTime? ReviewTime { get; private set; }

        public From From { get; private set; }
        
        /// <summary>
        ///  Проект який зв'язаний з відгуком
        /// </summary>
        public Project Project { get; private set; }

        private static Review FromJson(string json)
        {
            JObject jObject = JObject.Parse(json);
            return new Review
            {
                GradeAverage = jObject["grade_average"].ToObject<double?>(),
                GradePay = jObject["grade_pay"]?.ToObject<int>(),
                GradeDefinition = jObject["grade_definition"]?.ToObject<int>(),
                GradeRequirements = jObject["grade_requirements"]?.ToObject<int>(),
                GradeConnectivity = jObject["grade_connectivity"]?.ToObject<int>(),
                ReviewComment = jObject["review_comment"]?.ToObject<string>(),
                ReviewTime = jObject["review_time"]?.ToObject<DateTime>(),
                From = Model.From.FromJson(jObject["from"].ToString()),
                Project = Model.Project.FromJson(jObject["project"].ToString()),
                GradeCost = jObject["grade_cost"]?.ToObject<int>(),
                GradeQuality = jObject["grade_quality"]?.ToObject<int>(),
                GradeSchedule = jObject["grade_schedule"]?.ToObject<int>(),
                GradeProfessionalism = jObject["grade_professionalism"]?.ToObject<int>()
            };
        }

        internal static List<Review> ReviewsFromJson(string json)
        {
            var reviews = new List<Review>();
            JObject jObject = JObject.Parse(json);
            JArray jArray = JArray.Parse(jObject["reviews"].ToString());
            foreach (var review in jArray)
            {
                reviews.Add(FromJson(review.ToString()));
            }
            return reviews;
        }

    }
}
