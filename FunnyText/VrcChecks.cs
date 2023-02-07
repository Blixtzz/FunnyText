using SharpOSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastOsc;

namespace FunnyText
{
    public class VrcChecks
    {
        private static UDPListener listener = new SharpOSC.UDPListener(9001);

        public static void IsMuted()
        {
            var a = Directory.GetCurrentDirectory() + "\\ToastPackages\\MuteText.txt";
            var file = File.ReadAllLines(a);
            var ismuted = file[0].Trim();
            var isunmuted = file[1].Trim();

            byte[] bytes = listener.ReceiveBytes();
            if (bytes != null)
            {
                string result = System.Text.Encoding.UTF8.GetString(bytes);
                if (result.Contains("MuteSelf") && result.Contains("T"))
                {
                    Utilities.SendChatBox(ismuted);
                }
                if (result.Contains("MuteSelf") && result.Contains("F"))
                {
                    Utilities.SendChatBox(isunmuted);
                }
            }
        }
    }
}
