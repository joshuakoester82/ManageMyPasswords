using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace ManageMyPasswords
{
    public static class MachineIdentifier
    {
        public static byte[] GetUniqueIdentifier()
        {
            var identifier = new StringBuilder();

            // Add machine name
            identifier.Append(Environment.MachineName);

            // Add processor count
            identifier.Append(Environment.ProcessorCount);

            // Add OS info
            identifier.Append(Environment.OSVersion);

            // Add runtime identifier
            identifier.Append(RuntimeInformation.RuntimeIdentifier);

            // Add framework description
            identifier.Append(RuntimeInformation.FrameworkDescription);

            // Add OS architecture
            identifier.Append(RuntimeInformation.OSArchitecture);

            // Hash the combined string and return the byte array directly
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(identifier.ToString()));
            }
        }
    }
}
