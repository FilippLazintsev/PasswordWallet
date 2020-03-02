using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDataAccess
    {
        Password[] GetAllPasswords();
        Password[] GetPasswordBySite(string site);
        Password GetPasswordBySiteAndLogin(string site, string login);
        Password GetPasswordById(string id);

        bool SavePassword(string id, Password password);
        bool UpdatePassword(string id, Password password);
    }
}
