using System;
using System.Security.Cryptography;

namespace Domain.ValueObjects
{
    public class EncryptedPassword
    {
        public String Value {get;}
        public EncryptedPassword(String value)
        {
            this.Value = this.Encrypt(value);
        }

        private String Encrypt(String passwordString)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var keyDerevationFn = new Rfc2898DeriveBytes(passwordString, salt, 100000);
            byte[] hash = keyDerevationFn.GetBytes(20);
            
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
