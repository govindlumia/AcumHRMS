using System;
using System.Security.Cryptography;

namespace BaseLayer
{
    /// <summary>
    /// Provides methods for generating cryptographically-strong random numbers.
    /// </summary>
    /// <author>Disha Mittal</author>
    /// <created Date>10 May 2010</created>
    public static class RNG
    {
        private static byte[] randb = new byte[4];
        private static RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
        
        /// <summary>
        /// Generates a random non-negative number.  
        /// </summary>
        /// <author>Disha Mittal</author>
        /// <created Date>10 May 2010</created>
        public static int Next()
        {
            int value = 0;
            try
            {
                rand.GetBytes(randb);
                value = BitConverter.ToInt32(randb, 0);
                if (value < 0) value = -value;              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;
         
        }
        /// <summary>
        /// Generates a random non-negative number less than or equal to max.
        /// </summary>
        /// <param name="max">The maximum possible value.</param>
        /// <author>Disha Mittal</author>
        /// <created Date>10 May 2010</created>
        public static int Next(int max)
        {
            int value = 0;
            try
            {
                rand.GetBytes(randb);
                 value = BitConverter.ToInt32(randb, 0);
                value = value % (max + 1); // % calculates remainder
                if (value < 0) value = -value;               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;
         
        }
        /// <summary>
        /// Generates a random non-negative number bigger than or equal to min and less than or
        ///  equal to max.
        /// </summary>
        /// <param name="min">The minimum possible value.</param>
        /// param name="max">The maximum possible value.</param>
        /// <author>Disha Mittal</author>
        /// <created Date>10 May 2010</created>
        public static int Next(int min, int max)
        {
            int value = 0;
            try
            {
                value = Next(max - min) + min;          
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;
        }
    }
}