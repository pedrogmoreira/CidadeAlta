using System.Security.Cryptography;
using System.Text;

namespace CidadeAlta.Security.Helper
{
    public class PasswordHelper
    {/// <summary>
     /// Computes a MD5 hash of a password input.
     /// </summary>
     /// <param name="password">The password to be hashed.</param>
     /// <returns>The hashed password in MD5.</returns>
        public static string GetPasswordHash(string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the password string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                var sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

        /// <summary>
        /// Compares a password input and a stored passwordHash. 
        /// </summary>
        /// <param name="password">The password input to be validated.</param>
        /// <param name="passwordHash">The password hash stored.</param>
        /// <returns>True if equal.</returns>
        public static bool IsPasswordValid(string password, string passwordHash)
        {
            // Hash the password to be validated.
            string passwordToValidateHash = GetPasswordHash(password);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(passwordToValidateHash, passwordHash) == 0;
        }
    }
}
