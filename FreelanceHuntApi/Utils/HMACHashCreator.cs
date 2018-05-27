using System;
using System.Text;

namespace FreelanceHuntApi.Utils
{
    class HMACHashCreator
    {
        public static string GetSHA256Key(string data, string key, string @params = default(string))
        {

            //$url.$method.$post_params, $api_secret
            var enc = ASCIIEncoding.ASCII;
            var secretBytes = enc.GetBytes(data);
            var keyData = enc.GetBytes(key);
            System.Security.Cryptography.HMACSHA256 hash = new System.Security.Cryptography.HMACSHA256(keyData);
            var result = hash.ComputeHash(secretBytes);
            var resstring = Convert.ToBase64String(result);
            return resstring;
        }

    }
}
