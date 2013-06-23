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

        public AssistantForm()
        {
            InitializeComponent();
            speech = new Speech();
        }


        private void listenforanna_Click(object sender, EventArgs e)
        {
            speech.listenForWord("Anna");
            speech.talk("I'm listening Nick");

            string[] commands = { "Ask", "That's all for now" };
            string cmd = speech.recognizeOneWordFromGrammer(commands);

            switch (cmd)
            {
                case "Ask":
                    new Plugins.WolframAlpha.WA_process().processQuery(ref results, ref speech);
                    break;
                case "That's all for now":
                    speech.talk("Goodbye.");
                    System.Environment.Exit(0);
                    break;
                default:
                    speech.talk("I'm sorry, I cant do that.");
                    break;
            }

            listenforanna_Click(null, null);
        }

        private void ask_Click(object sender, EventArgs e)
        {

        }

        private void AssistantForm_Load(object sender, EventArgs e) {

        }
    }
}
