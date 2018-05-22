using FreelanceHuntAPI;
using System;

namespace Test
{
    class Program
    {
        static  void Main(string[] args)
        {
            FreelancehuntApi freelancehuntApi = new FreelancehuntApi("ivan213k", "9963e3dbaf46afe16e919797826db26dfc657439");
            var corespondentList = freelancehuntApi.GetAllCorrespondenceAsync().Result;
            var message = freelancehuntApi.GetMessageListAsync(corespondentList[0].MessageId).Result;
            Console.WriteLine(message[0].Text);

            Console.ReadKey();
        }
    }
}
