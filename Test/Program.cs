using FreelanceHuntApi.Enums;
using FreelanceHuntApi.Model;
using FreelanceHuntAPI;
using System;
using System.Collections.Generic;

namespace Test
{
    

    class Program
    {
        public static async void M(FreelancehuntApi freelancehuntApi)
        {
            var info = await freelancehuntApi.GetProjectsAsync();
        }

        static  void Main(string[] args)
        {
            FreelancehuntApi freelancehuntApi = new FreelancehuntApi("ivan213k", "9963e3dbaf46afe16e919797826db26dfc657439");

            List<Review> list = freelancehuntApi.GetReviewsAboutUserAsync("own_owl").Result;

            foreach (var item in list)
            {
                Console.WriteLine(item.GradeAverage);
            }

            

            Console.ReadKey(); 
        }
    }
}
