using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSystem.Backend.Models
{
   public class RegistratrionFormConstruct
    {
        public string name;
        public string password;
        public string application;
        public string comment;
        public string passwordHash;

        public RegistratrionFormConstruct(string name, string password, string application, string comment)
        {
            this.name = name;
            this.password = password;
            this.application = application;
            this.comment = comment;
        }
    }
}
