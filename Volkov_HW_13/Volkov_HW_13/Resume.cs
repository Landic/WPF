using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_13
{
    public class Resume
    {
        public string Fio, Age, FamilyStatus, Address, Email, IsInfo, IsLanguage, IsCommunicate;
        public Resume()
        {
            Fio = Age = FamilyStatus = Address = Email = IsInfo = IsLanguage = IsCommunicate = string.Empty;
        }
    }
}
