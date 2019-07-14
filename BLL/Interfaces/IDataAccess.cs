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

        bool SavePassword(string site, string login, string password);
        bool UpdatePassword(string site, string login, string password);
    }
}
