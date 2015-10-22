using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditDistance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Levenshtein lv = new Levenshtein(txtPalabra1.Text, txtPalabra2.Text);
            int result = lv.Dp();
            txtResultado.Text = result.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPalabra1.Text = "";
            txtPalabra2.Text = "";
            txtResultado.Text = "";

        }
    }
}
