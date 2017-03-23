using System.Collections.Generic;

namespace MeetAndGit.Models
{
    public class Users
    {
        public int Total_Count { get; set; }
        public bool Incomplete_Results { get; set; }
        public List<User> Items { get; set; }
    }
    public class User
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string Avatar_Url { get; set; }
        public string Gravatar_Id { get; set; }
        public string Url { get; set; }
        public string Html_Url { get; set; }
        public string Followers_Url { get; set; }
        public string Following_Url { get; set; }
        public string Gists_Url { get; set; }
        public string Starred_Url { get; set; }
        public string Subscriptions_Url { get; set; }
        public string Organizations_Url { get; set; }
        public string Repos_Url { get; set; }
        public string Events_Url { get; set; }
        public string Received_Events_Url { get; set; }
        public string Type { get; set; }
        public bool Site_Admin { get; set; }
        public double Score { get; set; }
    }
}
