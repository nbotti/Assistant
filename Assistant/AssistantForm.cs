using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant
{
    public partial class AssistantForm : Form
    {
        private Speech speech;
        private Wolfram wolfram;

        public AssistantForm()
        {
            InitializeComponent();
            speech = new Speech();
            wolfram = new Wolfram();
        }

        private void ask_Click(object sender, EventArgs e)
        {
            ask.Text = "Speak now!";
            string query = speech.recognizeDictation();
            ask.Text = "Querying Wolfram|Alpha...";
            speech.talk("One moment.");
            try
            {
                string[] result = wolfram.simpleQuery(query);
                returnResults(result);
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
                ask_Click(null, null);
            }
            
        }

        private void returnResults(string[] result)
        {
            results.Text = result[1];
            ask.Text = "Reading...";
            speech.talk(result[0].Replace("|", "-"));
            ask.Text = "Ask Wolfram Something";
        }

        private void listenforanna_Click(object sender, EventArgs e)
        {
            speech.listenForWord("Anna");
            speech.talk("I'm listening Nick");
            ask_Click(null, null);
            listenforanna_Click(null, null);
        }

        private void AssistantForm_Load(object sender, EventArgs e) {

        }
    }
}
