using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vjesala
{
    public partial class UnesenaRijec : Form
    {
        public string lol = "";
        public UnesenaRijec()
        {
            InitializeComponent();
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            lol = textBox1.Text.ToString().ToUpper();
            this.Close();
        }
    }
}
