using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpOSC;

namespace FunnyText
{
    public class Utilities
    {
        private static UDPSender sender = new SharpOSC.UDPSender("127.0.0.1", 9000);
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
