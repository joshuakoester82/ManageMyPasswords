using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ManageMyPasswords
{
    public class ConfigManager
    {
        private static readonly byte[] entropy;
        private const string ConfigFile = "config.enc";

        static ConfigManager()
        {
            entropy = MachineIdentifier.GetUniqueIdentifier();
            Logger.LogMessage($"Entropy: {Convert.ToBase64String(entropy)}");
        }

        public static void SaveConnectionString(string connectionString)
        {
            try
            {
                byte[] encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(connectionString), entropy, DataProtectionScope.CurrentUser);
                File.WriteAllBytes(ConfigFile, encryptedData);
                Logger.LogSecretMessage($"Saved encrypted data: {Convert.ToBase64String(encryptedData)}"); 
                
            }
            catch (Exception ex)
            {
                Logger.LogMessage($"Error saving connection string: {ex.Message}");
                throw;
            }
        }

        public static string LoadConnectionString()
        {
            if (!File.Exists(ConfigFile))
            {

                Logger.LogMessage("Config file does not exist.");
                return null;
            }
            try
            {
                byte[] encryptedData = File.ReadAllBytes(ConfigFile);
                Logger.LogSecretMessage($"Loaded encrypted data: {Convert.ToBase64String(encryptedData)}"); 
                byte[] decryptedData = ProtectedData.Unprotect(encryptedData, entropy, DataProtectionScope.CurrentUser);
                return Encoding.Unicode.GetString(decryptedData);
            }
            catch (CryptographicException ex)
            {
                Logger.LogSecretMessage($"Decryption error: {ex.Message}");
                Logger.LogSecretMessage($"Entropy used: {Convert.ToBase64String(entropy)}");
                DeleteConfigFile();
                return null;
            }
            catch (Exception ex)
            {
                Logger.LogMessage($"Error loading connection string: {ex.Message}");
                DeleteConfigFile();
                return null;
            }
        }

        private static void DeleteConfigFile()
        {
            try
            {
                File.Delete(ConfigFile);
                Logger.LogMessage("Deleted invalid config file.");
            }
            catch (Exception ex)
            {
                Logger.LogMessage($"Error deleting config file: {ex.Message}");
            }
        }
    }
}
