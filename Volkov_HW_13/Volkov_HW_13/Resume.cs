using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_13
{
    public class ResumeModel
    {
        public string Fullname;
        public string Age;
        public string Family;
        public string Address;
        public string Email;
        public string IsCPlusPlus;
        public string IsLanguage;
        public string IsOOP;

        public ResumeModel()
        {
            Fullname = string.Empty;
            Age = string.Empty;
            Family = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
            IsCPlusPlus = string.Empty;
            IsLanguage = string.Empty;
            IsOOP = string.Empty;
        }
    }
}
