using System;
using System.IO;
using System.Diagnostics;

namespace ManageMyPasswords
{
    internal static class Logger
    {
        private static readonly string fileName = "error_log.txt";
        private static readonly bool IsDebugMode;

        static Logger()
        {
            IsDebugMode = Debugger.IsAttached;
            InitializeLogFile();
        }

        private static void InitializeLogFile()
        {
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("File Log for ManageMyPasswords. Commencing Countdown, engines on. Check ignition and may God's love be with you.");
                    sw.WriteLine($"Created: {DateTime.Now}");
                    sw.WriteLine($"Machine Details: {Environment.MachineName}");
                    sw.WriteLine($"Debug Mode: {IsDebugMode}");
                }
            }
        }

        public static void LogMessage(string message, bool isSecret = false)
        {
            if (isSecret && !IsDebugMode)
            {
                Console.WriteLine("Secret information not logged in release mode.");
                return;
            }

            string logMessage = $"{DateTime.Now}: {message}";
            Console.WriteLine(logMessage);
            File.AppendAllText(fileName, $"\n{logMessage}");
        }

        public static void LogSecretMessage(string message)
        {
            LogMessage(message, true);
        }
    }
}