using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceHuntApi.Model
{
    class Skill
    {
        public int SkillId { get; set; }


        public string SkillName { get; set; }

        //public Skill FromJson(string response)
        //{
        //    JObject jObject = JObject.Parse(response);
        //    var listprop = jObject.Properties();
        //    foreach (var item in listprop)
        //    {
        //        item.n
        //    }
        //}
    }
}
