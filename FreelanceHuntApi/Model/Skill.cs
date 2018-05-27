using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FreelanceHuntApi.Model
{
    public class Skill
    {
        public Skill(int skillId, string skillName)
        {
            SkillId = skillId;
            SkillName = skillName;
        }

        public int SkillId { get; private set; }


        public string SkillName { get; private set; }


        public static List<string> SkillsFromJson(string response)
        {
            JObject jObject = JObject.Parse(response);
            var skills = new List<string>();
            foreach (var skill in jObject)
            {
                skills.Add(skill.Value.ToObject<string>());
            }
            return skills;
        }

        public static List<string> SkillsFromJarray(string response)
        {
            JArray jArray = JArray.Parse(response);
            var skills = new List<string>();
            foreach (var skill in jArray)
            {
                skills.Add(skill.ToObject<string>());
            }
            return skills;
        }
    }
}
