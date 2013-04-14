using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            string old = ask.Text;
            string query = speech.recognizeDictation();
            ask.Text = "Querying Wolfram|Alpha...";
            string result = wolfram.simpleQuery(query);
            results.Text = result;
            ask.Text = "Reading...";
            speech.talk(result);
            ask.Text = old;
        }
    }
}
