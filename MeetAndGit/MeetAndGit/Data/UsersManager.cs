using MeetAndGit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetAndGit.Data
{
    public class UsersManager
    {
        IRestService _restService;

        public UsersManager(IRestService service)
        {
            _restService = service;
        }

        public Task<List<Item>> GetUsersAsync(string location, string language)
        {
            return _restService.GetDataAsync(location, language);
        }
    }
}
