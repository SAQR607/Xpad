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

namespace Xpad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var di = new SaveFileDialog();
            di.Filter = "Text File|*.txt";
            di.FileName = "Xpad" + ".x";
            var ruselt= di.ShowDialog();
            if (ruselt == DialogResult.OK)
            {
                File.WriteAllText(di.FileName, richTextBox1.Text);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var di = new OpenFileDialog();
            di.Filter = "Text File|*.txt";
            var ruselt = di.ShowDialog();
            if (ruselt == DialogResult.OK)
            {
               richTextBox1.Text= File.ReadAllText(di.FileName);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(richTextBox1.Text);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(richTextBox1.Text);
                richTextBox1.Text = "";
            }
            catch { 
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text =richTextBox1.Text + Clipboard.GetText();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, new Point(100, 100));
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var font = new FontDialog();
            var result = font.ShowDialog();
            if (result == DialogResult.OK) ;
            {
                richTextBox1.Font = font.Font;
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.RightToLeft = RightToLeft.Yes;
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            var BackColor = new ColorDialog();
            var result = BackColor.ShowDialog();
            if (result == DialogResult.OK)
            {
                richTextBox1.BackColor = BackColor.Color;
            }

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            var BackColor = new ColorDialog();
            var result = BackColor.ShowDialog();
            if (result == DialogResult.OK)
            {
                richTextBox1.ForeColor = BackColor.Color;
            }
        }

        private void bunifuSlider1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.ZoomFactor = bunifuSlider1.Value;
            }
           catch
            {

            }
        }
    }
}
