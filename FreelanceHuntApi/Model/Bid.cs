using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FreelanceHuntApi.Model
{
    public class Bid
    {
        public int BidId { get; private set; }

        public bool IsHidden { get; private set; }

        public From From { get; private set; }

        public int? Amount { get; private set; }

        public string CurrencyCode { get; private set; }

        public int? DaysToDeliver { get; private set; }

        public string SafeType { get; private set; }

        public string Comment { get; private set; }

        public DateTime? PublicationDate { get; private set; }

        public bool? IsWinner { get; private set; }

        private static Bid FromJson(string response)
        {
            JObject jObject = JObject.Parse(response);
            Bid bid = new Bid
            {
                BidId = jObject["bid_id"].ToObject<int>(),
                IsHidden = jObject["is_hidden"].ToObject<bool>()
            };
            if (!bid.IsHidden)
            {
                bid.From = Model.From.FromJson(jObject["from"].ToString());
                bid.Amount = jObject["amount"]?.ToObject<int?>();
                bid.CurrencyCode = jObject["currency_code"]?.ToObject<string>();
                bid.DaysToDeliver = jObject["days_to_deliver"]?.ToObject<int?>();
                bid.SafeType = jObject["safe_type"]?.ToObject<string>();
                bid.Comment = jObject["comment"]?.ToObject<string>();
                bid.PublicationDate = jObject["datetime"]?.ToObject<DateTime>();
                bid.IsWinner = jObject["is_winner"]?.ToObject<bool?>();
            }
            return bid; 
        }

        internal static List<Bid> BidsFromJson(string response)
        {
            var jArray = JArray.Parse(response);
            List<Bid> bids = new List<Bid>();
            foreach (var bid in jArray)
            {
                bids.Add(FromJson(bid.ToString()));
            }
            return bids;
        }
    }
}
