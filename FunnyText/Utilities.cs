using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SharpOSC;

namespace FunnyText
{
    public class Utilities
    {
        private static UDPSender sender = new SharpOSC.UDPSender("127.0.0.1", 9000);
        private static int process = 0;
        private static string change = "";
        public static void SpotifySend()
        {
            if (process == 0)
            {
                process = GetSpotifyPid();
                Console.WriteLine($"process collected: {process}");
            }
            string window = Process.GetProcessById(process).MainWindowTitle;
            if (change != window)
            {
                change = window;
                SendChatBox(change);
                Console.WriteLine($"Song changed: {change}");
            }
            Task.Delay(1500).Wait();
        }
        private static int GetSpotifyPid()
        {
            foreach (Process p in Process.GetProcesses())
                if (p.ProcessName == "Spotify")
                {
                    return p.Id;
                }
            return 0;
        }
        public static void ToastModString(string dir)
        {
            dir = Directory.GetCurrentDirectory() + dir;
            var lines = File.ReadAllLines(dir);
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Trim();
                SendChatBox(line);
                Task.Delay(1500).Wait();
            }
        }
        public static void SendChatBox(string message)
        {
            sender.Send(new OscMessage("/chatbox/input", message, true, true));
        }
    }
}
