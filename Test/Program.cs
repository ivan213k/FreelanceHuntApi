using FreelanceHuntAPI;
using System;

namespace Test
{
    class Program
    {
        static  void Main(string[] args)
        {
            FreelancehuntApi freelancehuntApi = new FreelancehuntApi("ivan213k", "9963e3dbaf46afe16e919797826db26dfc657439");
            var profileInfo =  freelancehuntApi.GetAccountInfoAsync().Result;
            var response = freelancehuntApi.GetAllMessageAsync().Result;
            Console.ReadKey();
        }
    }
}
