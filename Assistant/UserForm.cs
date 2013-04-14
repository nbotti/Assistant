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
    public partial class UserForm : Form
    {
        private Speech speech;
        private Wolfram wolf = new Wolfram();

        public UserForm()
        {
            InitializeComponent();
            speech = new Speech();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Speak now!";
            MessageBox.Show(speech.recognizeDictation());
            button1.Text = "Click me to Recongnize";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string oldtext = button2.Text;
            button2.Text = "Working...";
            MessageBox.Show(wolf.simpleQuery("Who is Donald Duck?"));
            button2.Text = oldtext;
        }
    }
}
