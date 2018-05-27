using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace FreelanceHuntApi.Model
{
    public class Snippet
    {
        public int SkillId { get; private set; }

        public string SkillName { get; private set; }

        public string SnippetUrl { get; private set; }

        public DateTime SnippetAdditionTime { get; private set; }

        public string SnippetComment { get; private set; }

        public string SnippetContentType { get; private set; }

        public ulong SnippetFileSize { get; private set; }

        public string SnippetName { get; private set; }

        public string SnippetFileName { get; private set; }

        public string SnippetThumbnail { get; private set; }

        public int ViewsCount { get; private set; }

        public int VotesUp { get; private set; }

        private static Snippet FromJson(string response)
        {
            JObject jObject = JObject.Parse(response);
            return new Snippet
            {
                SkillId = jObject["skill_id"].ToObject<int>(),
                SkillName = jObject["skill_name"].ToObject<string>(),
                SnippetUrl = jObject["snippet"].ToObject<string>(),
                SnippetAdditionTime = jObject["snippet_addition_time"].ToObject<DateTime>(),
                SnippetComment = jObject["snippet_comment"].ToObject<string>(),
                SnippetContentType = jObject["snippet_content_type"].ToObject<string>(),
                SnippetFileSize = jObject["snippet_file_size"].ToObject<ulong>(),
                SnippetFileName = jObject["snippet_filename"].ToObject<string>(),
                SnippetName = jObject["snippet_name"].ToObject<string>(),
                SnippetThumbnail = jObject["snippet_thumbnail"].ToObject<string>(),
                ViewsCount = jObject["views"].ToObject<int>(),
                VotesUp = jObject["votes_up"].ToObject<int>()
            };
        }

        public static List<Snippet> SnippetsFromJson(string response)
        {
            JArray jArray = JArray.Parse(response);
            var snippets = new List<Snippet>();
            foreach (var snippet in jArray)
            {
                snippets.Add(FromJson(snippet.ToString()));
            }
            return snippets;
        }
    }
}
