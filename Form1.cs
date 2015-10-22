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

        /// <summary>
        /// Calcula el mínimo entre tres variables diferentes.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private int min(int a, int b,int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        /// <summary>
        /// Método que mediante DP (programación dinámica)
        /// calcula la diferencia entre una palabra y otra.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private int Levenshtein(string p1, string p2)
        {
            int t1 = p1.Length;
            int t2 = p2.Length;
            int[,] dp = new int[1000, 1000];

            for (int i = 0; i < t1; i++)
                dp[i,0] = i;

            for (int i = 0; i < t2; i++)
                dp[0,i] = i;

            for (int i=1;i<t1;i++)
            {
                for(int j=1;j<t2;j++)
                {
                    int cost = (p1[i] == p2[j]) ? 0 : 1;
                    dp[i,j] = min(dp[i-1,j] + 1, dp[i, j-1] + 1, dp[i - 1, j - 1] + cost);
                }
            }
            return dp[t1 - 1, t2 - 1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = Levenshtein(txtPalabra1.Text,txtPalabra2.Text);
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
