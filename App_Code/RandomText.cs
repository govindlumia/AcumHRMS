using System;

namespace BaseLayer
{
    /// <summary>
    /// Provides methods for generating random texts.
    /// </summary>
    public static class RandomText
    {
        /// <summary>
        /// Generates an 4 letter random text.
        /// </summary>
        /// <author>Disha Mittal</author>
        /// <created Date>10 May 2010</created>
        public static string Generate()
        {
            string s = "";
            try
            {
                // Generate random text
               
                char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                int index;
                int lenght = RNG.Next(2, 2);
                for (int i = 0; i < lenght; i++)
                {
                    index = RNG.Next(chars.Length - 1);
                    s += chars[index].ToString();
                }             
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return s;
        }
    }
}