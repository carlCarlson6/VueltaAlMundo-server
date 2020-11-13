using System.Text.RegularExpressions;
using System;
using Domain.Exceptions;
using System.Security.Cryptography;

namespace Domain.ValueObjects
{
    public class Password
    {
        private readonly Regex validationPattern = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
        public String Value { get => encrypted.Value; }
        private readonly EncryptedPassword encrypted;
        
        public Password(String value)
        {
            this.ValidateFormat(value);
            this.encrypted = new EncryptedPassword(value);
        }

        public Password(EncryptedPassword encryptedPassword) => this.encrypted = encryptedPassword;

        private void ValidateFormat(String passwordString)
        {
            if(String.IsNullOrEmpty(passwordString) || String.IsNullOrWhiteSpace(passwordString))
            {
                throw new EmptyNullWhiteSpaceStringException(nameof(Password));
            }
            if(!this.validationPattern.IsMatch(passwordString))
            {
                throw new NotValidPasswordException();
            }
        }

        private Boolean Verify(String inputPassword)
        {
            byte[] hashedPasswordBytes = Convert.FromBase64String(this.Value);
            byte[] salt = new byte[16];
            Array.Copy(hashedPasswordBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            
            for (int i=0; i < 20; i++)
                if (hashedPasswordBytes[i+16] != hash[i])
                    return false;
            
            return true;
        }

    }
}
