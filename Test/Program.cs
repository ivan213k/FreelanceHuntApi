using FreelanceHuntApi.Enums;
using FreelanceHuntApi.Model;
using FreelanceHuntAPI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        public static async Task<List<Review>> GetCorrespondenceAsync(FreelancehuntApi freelancehuntApi)
        {
            return await freelancehuntApi.GetReviewsAboutUserAsync("dxsxsx");
        }

        static  void Main(string[] args)
        {
            FreelancehuntApi freelancehuntApi = new FreelancehuntApi("ivan213k", "9963e3dbaf46afe16e919797826db26dfc657439");
            var d = GetCorrespondenceAsync(freelancehuntApi).Result;

            Console.ReadKey(); 
        }
    }
}
