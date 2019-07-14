using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class FileDataAccess : Interfaces.IDataAccess
    {
        public Password[] GetAllPasswords()
        {
            throw new NotImplementedException();
        }

        public Password[] GetPasswordBySite(string site)
        {
            throw new NotImplementedException();
        }

        public Password GetPasswordBySiteAndLogin(string site, string login)
        {
            throw new NotImplementedException();
        }

        public bool SavePassword(string site, string login, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassword(string site, string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
