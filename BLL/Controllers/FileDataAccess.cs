using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;


namespace BLL
{
    class FileDataAccess : Interfaces.IDataAccess
    { 
        static public string MainFile => System.Configuration.ConfigurationSettings.AppSettings.Get("MainFile");

        public Password[] GetAllPasswords()
        {
            var RawFile = File.ReadAllLines(MainFile);
            var result = new Password[RawFile.Length];

            for(int i = 0; i < RawFile.Length; i++)
            {
                result[i] = MapRawPassword(RawFile[i]);
            }

            return result;

        }

        private Password MapRawPassword(string raw)
        {
            var result = new Password();

            result.site = raw.Split(';')[0];
            result.login = raw.Split(';')[1];
            result.password = raw.Split(';')[2];
             
            return result;
        }

        public Password[] GetPasswordBySite(string site)
        {
            var RawFile = File.ReadAllLines(MainFile);
            var result = new Password[RawFile.Length];

            for (int i = 0; i < RawFile.Length; i++)
            {
                var tmpResult = MapRawPassword(RawFile[i]);
                if(tmpResult.site == site)
                {
                    result[i] = tmpResult;
                }
            }

            return result;
        }

        public Password GetPasswordBySiteAndLogin(string site, string login)
        {
            var RawFile = File.ReadAllLines(MainFile);
            for (int i = 0; i < RawFile.Length; i++)
            {
                var tmpResult = MapRawPassword(RawFile[i]);
                if (tmpResult.site == site && tmpResult.login == login)
                {
                    return tmpResult;
                }
            }

            return new Password();
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
