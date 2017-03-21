using MeetAndGit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeetAndGit.Data
{
    public class RestService : IRestService
    {
        HttpClient client;
        public List<User> Users { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 25600;
        }

        public async Task<List<User>> GetDataAsync(string location, string language)
        {
            Users = new List<User>();

            // RestUrl = https://api.github.com/search

            var uri = new Uri(string.Format(Constants.RestUrl, $"users?q=location:{location}+language:{language}"));

            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Users = JsonConvert.DeserializeObject<List<User>>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Users;
        }
    }
}
