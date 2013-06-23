using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant.Plugins.OpenAWebsite
{
    class OAW_process : Plugin
    {
        public override void processQuery(ref TextBox tb, ref Speech speech)
        {
            speech.talk("Which site?");
            Dictionary<string, string> sites = new Dictionary<string, string>();
            using (StreamReader sr = new StreamReader("sites.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sites.Add(line.Split(',')[0], line.Split(',')[1]);
                }
            }

            string addr = speech.recognizeOneWordFromGrammer(sites.Keys.ToArray<string>());

            Process c = new Process();
            c.StartInfo.FileName = "chrome.exe";
            c.StartInfo.Arguments = sites[addr];
            c.Start();
        }
    }
}
