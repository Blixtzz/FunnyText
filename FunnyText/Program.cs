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
        private static void Main(string[] args)
        {
            Console.WriteLine("choose a chatbox\n1 = read from text file (\\ToastPackages\\YourFavoritePhrases.txt)\n2 = muted check (dont spam mute it rate limits you)");
            string dir = Console.ReadLine();
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

