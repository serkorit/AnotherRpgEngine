using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Engine
{
    /// <summary>
    /// Random number generator for engine
    /// </summary>
    public static class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider generator = new RNGCryptoServiceProvider();

        /// <summary>
        /// Generate random number
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>Number between min and max values</returns>
        public static int Generate(int min, int max)
        {
            byte[] randomNumber = new byte[1];

            generator.GetBytes(randomNumber);

            double asc2ConvertBytes = Convert.ToDouble(randomNumber[0]);

            double multy = Math.Max(0, (asc2ConvertBytes) / 255d);
            int range = max - min + 1;
            double randomInRange = Math.Floor(multy * range);

            return (int)(min + randomInRange);
        }
    }
}
