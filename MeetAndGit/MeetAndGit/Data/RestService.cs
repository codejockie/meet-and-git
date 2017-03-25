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

        /// <summary>
        /// Gets a list of users based on their location and programming language
        /// </summary>
        /// <param name="location">Location</param>
        /// <param name="language">Programming Language</param>
        /// <returns>Returns a list of users</returns>
        public async Task<List<User>> GetDataAsync(string location, string language)
        {
            // RestUrl = https://api.github.com/

            var uri = new Uri(string.Format(Constants.RestUrl, $"search/users?q=location:{location}+language:{language}"));

            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Users = JsonConvert.DeserializeObject<Users>(content);
            }

            return Users.Items;
        }

        /// <summary>
        /// Gets a specified user's details by their username
        /// </summary>
        /// <param name="username">Username for a user</param>
        /// <returns>UserInfo</returns>
        public async Task<UserInfo> GetUserInfoAsync(string username)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, $"users/{username}"));

            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                UserInfo = JsonConvert.DeserializeObject<UserInfo>(content);
            }

            return UserInfo;
        }
    }
}
