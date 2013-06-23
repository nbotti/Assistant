using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant
{
    public abstract class Plugin
    {
        /// <summary>
        /// This method is called immediately after the user says your keyword.
        /// Display text to the user by manipulating the passed textbox object
        /// Verbal interaction with the user using the passed Speech object
        /// </summary>
        public abstract void processQuery(ref TextBox tb, ref Speech speech);
    }
}
