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
            result.id = raw.Split(';')[3];
             
            return result;
        }

        private string SerializePassword(Password password)
        {
            return string.Format("{0};{1};{2};{3}", password.site, password.login, password.password, password.id);
        }

        public Password[] GetPasswordBySite(string site)
        {
            var RawFile = File.ReadAllLines(MainFile);
            var result = new List<Password>();

            for (int i = 0; i < RawFile.Length; i++)
            {
                var tmpResult = MapRawPassword(RawFile[i]);
                if(tmpResult.site == site)
                {
                    result.Add(tmpResult);
                }
            }

            return result.ToArray();
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

        public Password GetPasswordById(string id)
        {
            var RawFile = File.ReadAllLines(MainFile);
            for (int i = 0; i < RawFile.Length; i++)
            {
                var tmpResult = MapRawPassword(RawFile[i]);
                if (tmpResult.id == id)
                {
                    return tmpResult;
                }
            }

            return new Password();
        }

        public bool SavePassword(string id, Password password)
        {
            var RawFile = File.ReadAllLines(MainFile);
            RawFile.ToList().Add(SerializePassword(password));
            try
            {
                File.WriteAllLines(MainFile, RawFile.ToArray());
            }
            catch { return false; }
            return true;

        }

        public bool UpdatePassword(string id, Password password)
        {
            var RawFile = File.ReadAllLines(MainFile);
            for (int i = 0; i < RawFile.Length; i++)
            {
                var tmpResult = MapRawPassword(RawFile[i]);
                if (tmpResult.id == id)
                {
                    RawFile[i] = SerializePassword(password);
                    try
                    {
                        File.WriteAllLines(MainFile, RawFile.ToArray());
                    }
                    catch { return false; }
                    return true;
                }
            }
            return false;

        }
    }
}
