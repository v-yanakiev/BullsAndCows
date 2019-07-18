using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows.Services
{
    public class RNGHandler
    {
        private readonly int NumberSize;
        private readonly Random _rnd;
        private readonly List<string> _permutations;

        public RNGHandler(IOptions<AppSettings> appSettings)
        {
            this.NumberSize = appSettings.Value.NumberDigitSize;
            _rnd = new Random();
            this._permutations = GeneratePermutations(NumberSize).ToList();
        }
        public int GenerateNumberBetweenLimits(int min,int max)
        {
            return _rnd.Next(min, max);
        }
        public IEnumerable<string> GeneratePermutations(int size)
        {
            if (size > 0)
            {
                foreach (string s in GeneratePermutations(size - 1))
                {
                    foreach (char n in "1234567890")
                    {
                        string generated = s + n;
                        if ((!s.Contains(n)) && (IsComposedOfUniqueDigits(generated)))
                        {
                            yield return generated;
                        }
                    }
                }
            }
            else
            {
                yield return "";
            }
            bool IsComposedOfUniqueDigits(string number)
            {
                return number.Distinct().Count() == number.Length;
            }
        }
        public string GenerateUniqueDigitsNumber()
        {
            string randomString = this._permutations[_rnd.Next(0, this._permutations.Count)];
            return randomString;
        }
    }
}
