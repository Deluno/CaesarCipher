using System;
using System.Windows.Forms;

namespace CaesarCipher
{
    public partial class Form1 : Form
    {
        EDUtils ed = new EDUtils();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int offset = random.Next(1, 25);
            richTextBox2.Text = ed.Encode(richTextBox1.Text, offset);
            richTextBox1.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ed.Decode(richTextBox2.Text);
            richTextBox2.Clear();
        }
    }
}
