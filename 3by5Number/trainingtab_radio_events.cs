using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _3by5Number
{
    public partial class Form1 : Form
    {

        private void r0_CheckedChanged(object sender, EventArgs e)
        {
            if (r0.Checked == true)
            {
                radioDigit = 0;
                reloadTraining(0);
            }
        }

        private void r1_CheckedChanged(object sender, EventArgs e)
        {
            if (r1.Checked == true)
            {
                radioDigit = 1;
                reloadTraining(1);
            }
        }

        private void r2_CheckedChanged(object sender, EventArgs e)
        {
            if (r2.Checked == true)
            {
                radioDigit = 2;
                reloadTraining(2);
            }
        }

        private void r3_CheckedChanged(object sender, EventArgs e)
        {
            if (r3.Checked == true)
            {
                radioDigit = 3;
                reloadTraining(3);
            }
        }

        private void r4_CheckedChanged(object sender, EventArgs e)
        {
            if (r4.Checked == true)
            {
                radioDigit = 4;
                reloadTraining(4);
            }
        }

        private void r5_CheckedChanged(object sender, EventArgs e)
        {
            if (r5.Checked == true)
            {
                radioDigit = 5;
                reloadTraining(5);
            }
        }

        private void r6_CheckedChanged(object sender, EventArgs e)
        {
            if (r6.Checked == true)
            {
                radioDigit = 6;
                reloadTraining(6);
            }
        }

        private void r7_CheckedChanged(object sender, EventArgs e)
        {
            if (r7.Checked == true)
            {
                radioDigit = 7;
                reloadTraining(7);
            }
        }

        private void r8_CheckedChanged(object sender, EventArgs e)
        {
            if (r8.Checked == true)
            {
                radioDigit = 8;
                reloadTraining(8);
            }
        }

        private void r9_CheckedChanged(object sender, EventArgs e)
        {
            if (r9.Checked == true)
            {
                radioDigit = 9;
                reloadTraining(9);
            }
        }

    }
}
