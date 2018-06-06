using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace FreelanceHuntApi.Model
{
    public class Attachment
    {
        public string AttachmentUrl { get; private set; }

        public string FileName { get; private set; }

        public ulong FileSize { get; private set; }

        public string ContentType { get; private set; }

        public string AttachmentThumbnail { get; private set; }

        private static Attachment FromJson(string response)
        {
            JObject jObject = JObject.Parse(response);
            return new Attachment
            {
                AttachmentUrl = jObject["attachment"].ToObject<string>(),
                FileName = jObject["filename"].ToObject<string>(),
                FileSize = jObject["filesize"].ToObject<ulong>(),
                ContentType = jObject["content_type"].ToObject<string>(),
                AttachmentThumbnail = jObject["attachment_thumbnail"]?.ToObject<string>()
            };
        }

        internal static List<Attachment> AttachmentsFromJson(string response)
        {
            if (response == null) return new List<Attachment>();
            var attachmentList = new List<Attachment>();

            JsonReader jsonReader = new JsonTextReader(new StringReader(response));

            JToken jToken = JObject.ReadFrom(jsonReader);

            foreach (var attachment in jToken.Children())
            {
                attachmentList.Add(Attachment.FromJson(attachment.ToString()));
            }
            return attachmentList;
        }
    }
}
