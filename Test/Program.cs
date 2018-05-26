using FreelanceHuntApi.Enums;
using FreelanceHuntAPI;
using System;

namespace Test
{
    class Program
    {
        static  void Main(string[] args)
        {
            FreelancehuntApi freelancehuntApi = new FreelancehuntApi("ivan213k", "9963e3dbaf46afe16e919797826db26dfc657439");

            var projects = freelancehuntApi.GetProjectsAsync(2, 50).Result;
            foreach (var item in projects)
            {
                var liist = freelancehuntApi.GetBidsOnProject(item.ProjectId).Result;
                foreach (var item1 in liist)
                {
                    Console.WriteLine(item1.IsHidden);
                }
            }
            
           
            Console.ReadKey(); 
        }
    }
}
