using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

using Woc.Book.Base.Service;

namespace Woc.Book.Base
{
    public class UtilityController
    {
        private const int _saltLength = 16;

        public static DateTime StringToDate(String ValueInString)
        {
            return DateTime.ParseExact(ValueInString, Properties.Resources.DateFormat, null);
        }

        public static DateTime StringToDate(Object Value)
        {
            return DateTime.ParseExact(Value.ToString(), Properties.Resources.DateFormat, null);
        }

        public void EncryptSaltPassword(String password, out byte[] hash, out byte[] salt)
        {
            HashAlgorithm hashAlgorithm = SHA512.Create();
            salt = new byte[_saltLength];
            RNGCryptoServiceProvider rngService = new RNGCryptoServiceProvider();
            rngService.GetBytes(salt);

            List<byte> encPassword = new List<byte>(Encoding.Unicode.GetBytes(password));
            encPassword.AddRange(salt);
            hash = hashAlgorithm.ComputeHash(encPassword.ToArray());
        }

        public bool VerifySaltPassword(String password, byte[] hash, byte[] salt)
        {
            try
            {
                if (salt == null)
                {
                    return false;
                }

                HashAlgorithm hashAlgorithm = SHA512.Create();

                List<byte> buffer = new List<byte>(Encoding.Unicode.GetBytes(password));
                buffer.AddRange(salt);

                byte[] computedHash = hashAlgorithm.ComputeHash(buffer.ToArray());
                bool isEqual = true;

                isEqual = (computedHash.Length == hash.Length);

                if (isEqual)
                {
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        isEqual &= computedHash[i] == hash[i];
                        if (!isEqual)
                        {
                            break;
                        }
                    }
                }

                return isEqual;
            }
            catch
            {
                return false;
            }
        }
    }
}
