using System;
using System.Security.Cryptography;
using System.Linq;

namespace ManageMyPasswords
{
    public class PasswordGenerator
    {
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NumericChars = "0123456789";
        private const string SpecialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        public string GeneratePassword(int length, bool includeLowercase = true, bool includeUppercase = true,
                                       bool includeNumbers = true, bool includeSpecial = true)
        {
            if (length < 8)
                throw new ArgumentException("Password length must be at least 8 characters.");

            string chars = "";
            if (includeLowercase) chars += LowercaseChars;
            if (includeUppercase) chars += UppercaseChars;
            if (includeNumbers) chars += NumericChars;
            if (includeSpecial) chars += SpecialChars;

            if (string.IsNullOrEmpty(chars))
                throw new ArgumentException("At least one character set must be selected.");

            var bytes = new byte[length];
            RandomNumberGenerator.Fill(bytes);

            return new string(bytes.Select(b => chars[b % chars.Length]).ToArray());
        }

        public bool IsPasswordStrong(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsDigit) &&
                   password.Any(c => SpecialChars.Contains(c));
        }
    }
}