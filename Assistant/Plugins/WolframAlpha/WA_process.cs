using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant.Plugins.WolframAlpha
{
    class WA_process : Plugin
    {
        public string Keyword { get; set; }
        private Wolfram wolfram = new Wolfram();
        
        public override void processQuery(ref TextBox tb, ref Speech speech)
        {
            speech.talk("Preparing to query Wolfram. What would you like to know?");
            string query = speech.recognizeDictation();
            tb.Text = "Querying Wolfram|Alpha...";
            speech.talk("One moment.");
            try
            {
                string[] result = wolfram.simpleQuery(query);
                tb.Text = result[1];
                speech.talk(result[0].Replace("|", "-"));
            }
            catch (AmbiguousQueryException aqe)
            {
                speech.talk(aqe.Message);
                speech.talk("Please restate your query, optionally using one of the following interpretations.");
                int count = 1;
                foreach (var dym in aqe.DidYouMeans)
                {
                    speech.talk(count + ": " + dym.Value);
                }
                processQuery(ref tb, ref speech);
            }

        }
    }
}
