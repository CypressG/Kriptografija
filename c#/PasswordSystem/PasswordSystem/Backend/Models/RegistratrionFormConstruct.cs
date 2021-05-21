using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSystem.Backend.Models
{
   public class RegistratrionFormConstruct
    {
        public string name { get; set; }
        public string password { get; set; }
        public string application { get; set; }
        public string comment { get; set; }
        public string passwordHash { get; set; }

        public RegistratrionFormConstruct()
        {

        }
        public RegistratrionFormConstruct(string name, string password, string application, string comment)
        {
            this.name = name;
            this.password = password;
            this.application = application;
            this.comment = comment;
        }
    }
}
