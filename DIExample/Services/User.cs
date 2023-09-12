using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class User : ICitiesService
    {
        private List<string> _users;

        public User()
        {
            _users = new List<string>()
            {
               "Zé",
               "Alon",
               "Nasko"
            };
        }

        public List<string> GetCities()
        {
            return _users;
        }
    }
}
