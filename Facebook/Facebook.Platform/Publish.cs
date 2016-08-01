using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Platform
{
    public class Publish
    {
        public static async Task PostToFeedAsync(string accessToken, string link, string message)
        {
            // Use HttpClient
            using (var client = new HttpClient())
            {
                // Set variable values for post to facebook
                string uri = "https://graph.facebook.com/me/feed?";

                // Formulate querystring for graph post
                StringContent queryString = new StringContent("access_token=" + accessToken + "&link=" + link + "&message=" + message);

                // Post to facebook /{page-id}/feed edge
                HttpResponseMessage response = await client.PostAsync(new Uri(uri), queryString);
            }
        }

        public static async Task PostToPageAsync(string pageId, string accessToken, string link, string picture, string name, string description)
        {
            // Use HttpClient
            using (var client = new HttpClient())
            {
                // Set variable values for post to facebook
                string uri = "https://graph.facebook.com/v2.5/" + pageId + "/feed?";

                // Formulate querystring for graph post
                StringContent queryString = new StringContent("access_token=" + accessToken + "&link=" + link + "&picture=" + picture + "&name=" + name + "&description=" + description);

                // Post to facebook /{page-id}/feed edge
                HttpResponseMessage response = await client.PostAsync(new Uri(uri), queryString);
            }
        }
    }
}
