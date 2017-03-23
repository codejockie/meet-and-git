namespace MeetAndGit.Models
{
    public class UserInfo
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string Avatar_Url { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Blog { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public int Public_Repos { get; set; }
        public int Public_Gists { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
    }
}
