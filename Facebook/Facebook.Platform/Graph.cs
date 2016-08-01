using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Facebook.Models;

namespace Facebook.Platform
{
    public class Graph
    {
        public static async Task<User> GetUser(string accessToken)
        {
            User user = new User();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://graph.facebook.com/");
                HttpResponseMessage response = await client.GetAsync("me?fields=id,name,first_name,last_name,email,gender,link,locale&access_token=" + accessToken);

                if (response.IsSuccessStatusCode)
                {
                    string strJson = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(strJson);

                    return user;
                }
                else
                    return null;
            }
        }

    }
}
