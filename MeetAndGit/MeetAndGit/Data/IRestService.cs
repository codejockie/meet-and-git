using System.Collections.Generic;
using System.Threading.Tasks;
using MeetAndGit.Models;

namespace MeetAndGit.Data
{
    public interface IRestService
    {
        Task<List<User>> GetDataAsync(string location, string language);
    }
}