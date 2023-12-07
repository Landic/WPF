using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_15
{
    public class User
    {
        private static User example;
        public string Login { get; set; }
        public string Password { get; set; }
        public static User Example
        {
            get
            {
                if (example == null) example = new User();
                return example;
            }
        }
        private User()
        {
            Login = Password = null;
        }
    }
}
