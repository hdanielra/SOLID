using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_S.Models
{
    public class User
    {

        public User(string _email, string _password)
        {
            this.email = _email;
            this.password = _password;
        }
        public string email { get; set; }
        public string password { get; set; }
    }
}
