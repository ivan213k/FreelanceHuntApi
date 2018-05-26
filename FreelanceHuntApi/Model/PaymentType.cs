using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceHuntApi.Model
{
    public class PaymentType
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        public PaymentType(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public static List<PaymentType> FromJson(string response)
        {
            if (response == null) return new List<PaymentType>();
            
            List<PaymentType> listPay = new List<PaymentType>();

            JObject jObject = JObject.Parse(response);
            foreach (var item in jObject)
            {
                listPay.Add(new PaymentType(item.Value.ToObject<string>(), Convert.ToInt32(item.Key)));
            }
            return listPay;
        }
    }
}
