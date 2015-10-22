using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditDistance
{
    class Levenshtein
    {
        private string s1, s2;
        private int[,] dp = null;
        private int t1;
        private int t2;
        public Levenshtein(string s1,string s2)
        {
            this.s1 = s1;
            this.s2 = s2;

            t1 = s1.Length;
            t2 = s2.Length;
            dp = new int[1000, 1000];

            for (int i = 0; i < t1; i++)
                dp[i, 0] = i;

            for (int i = 0; i < t2; i++)
                dp[0, i] = i;
        }
        
        /// <summary>
        /// Calcula el mínimo entre tres variables diferentes.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private int min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        /// <summary>
        /// Método que mediante DP (programación dinámica)
        /// calcula la diferencia entre una palabra y otra.
        /// </summary>
        /// <returns></returns>
        public int Dp()
        {
            for (int i = 1; i < t1; i++)
            {
                for (int j = 1; j < t2; j++)
                {
                    int cost = (this.s1[i] == this.s2[j]) ? 0 : 1;
                    dp[i, j] = min(dp[i - 1, j] + 1, dp[i, j - 1] + 1, dp[i - 1, j - 1] + cost);
                }
            }
            return dp[t1 - 1, t2 - 1];
        }
    }
    
}
