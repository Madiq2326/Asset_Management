using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Role_Name { get; set; }
    }
}
