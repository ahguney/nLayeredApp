using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key; // abc12
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // salt + hash
            }
        }

        public static bool VerifyPassword(string password,byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt)) // salt
            {
                byte[] computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // salt + hash
                for(int i = 0; i < computeHash.Length ;i++)
                {
                    if (passwordHash[i] != computeHash[i]) // salt + hash
                        return false;
                }
                return true;
            }
        }
    }
}
