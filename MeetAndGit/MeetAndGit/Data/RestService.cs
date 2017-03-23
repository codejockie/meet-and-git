using MeetAndGit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MeetAndGit.Data
{
    public class RestService : IRestService
    {
        HttpClient client;
        public Users Users { get; private set; }
        public UserInfo UserInfo { get; set; }

        public RestService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Fiddler");
        }

        public async Task<List<User>> GetDataAsync(string location, string language)
        {
            // RestUrl = https://api.github.com/search

            var uri = new Uri(string.Format(Constants.RestUrl, $"search/users?q=location:{location}+language:{language}"));

            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Users = JsonConvert.DeserializeObject<Users>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Users.Items;
        }

        public async Task<UserInfo> GetUserInfoAsync(string username)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, $"users/{username}"));

            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    UserInfo = JsonConvert.DeserializeObject<UserInfo>(content);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return UserInfo;
        }
    }
}
