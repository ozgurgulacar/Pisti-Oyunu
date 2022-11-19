using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pisti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            int send=101;
            if (rd101.Checked==true)
            {
                send = 101;
            }
            else if (rd151.Checked==true)
            {
                send = 151;
            }
            else if (rd201.Checked==true)
            {
                send = 201;
            }
            pisti pst = new pisti();
            pst.biter = send;
            pst.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rd101.Checked = true;
        }
    }
}
