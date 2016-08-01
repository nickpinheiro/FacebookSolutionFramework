using System;
using System.Threading.Tasks;
using System.Net.Http;
using Facebook.Models;

namespace Facebook.Platform
{
    public class Login
    {
        private const string oauthBaseUri = "https://graph.facebook.com/oauth/";

        public static async Task<User> GetAccessToken(string facebookAppId, string facebookAppSecret, string facebookAppDomain, string code)
        {
            string accessToken = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(oauthBaseUri);
                HttpResponseMessage response = await client.GetAsync("access_token?client_id=" + facebookAppId + "&client_secret=" + facebookAppSecret + "&redirect_uri=" + facebookAppDomain + "&code=" + code);
                if (response.IsSuccessStatusCode)
                {
                    accessToken = await response.Content.ReadAsStringAsync();
                    string replace = accessToken.Replace("access_token=", "");

                    // Split the access token and expiration from the single string
                    string[] words = replace.Split('&');
                    accessToken = words[0];

                    User user = await Graph.GetUser(accessToken);
                    user.access_token = accessToken;

                    return user;
                }
                return null;
            }
        }

        public static async Task<string> GetExtendedAccessToken(string facebookAppId, string facebookAppSecret, string accessToken)
        {
            string extendedAccessToken;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(oauthBaseUri);
                HttpResponseMessage response = await client.GetAsync("grant_type = fb_exchange_token & client_id = " + facebookAppId + " & client_secret = " + facebookAppSecret + " & fb_exchange_token = " + accessToken);

                if (response.IsSuccessStatusCode)
                {
                    extendedAccessToken = await response.Content.ReadAsStringAsync();
                    return extendedAccessToken;
                }
            }

            return null;
        }
    }
}
