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
        public static string ismuted = "";
        public static string isunmuted = "";
        public static void IsMuted()
        {
            byte[] bytes = OscMain.listener.ReceiveBytes();
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
