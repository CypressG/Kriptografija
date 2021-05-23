using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSystem.Backend.Models
{
    public class LoginValidationConstructcs
    {
        public string username;
        public string hashValue;

        public LoginValidationConstructcs()
        {

        }
        public LoginValidationConstructcs(string username, string hashValue)
        {
            this.username = username;
            this.hashValue = hashValue;
        }
    }
}
