using SharpOSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using FunnyText;

namespace ToastOsc
{
    class OscMain
    {
        public static UDPSender sender = new SharpOSC.UDPSender("127.0.0.1", 9000);
        public static UDPListener listener = new SharpOSC.UDPListener(9001);

        private static void Main(string[] args)
        {
            Console.WriteLine("choose a chatbox\n1 = read from text file (\\ToastPackages\\YourFavoritePhrases.txt)\n2 = muted check (dont spam mute it rate limits you)");
            string dir = Console.ReadLine();
            var a = Directory.GetCurrentDirectory() + "\\ToastPackages\\MuteText.txt";
            var file = File.ReadAllLines(a);
            VrcChecks.ismuted = file[0].Trim();
            VrcChecks.isunmuted = file[1].Trim();
            while (true)
            {
                switch(dir)
                {
                    case "1": Utilities.ToastModString("\\ToastPackages\\YourFavoritePhrases.txt");
                        break;

                    case "2": VrcChecks.IsMuted();
                        break;
                }
            }
        }

    }
}

