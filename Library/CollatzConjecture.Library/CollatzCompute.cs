using System;
using System.Collections.Generic;

namespace CollatzConjecture.Library
{
    public abstract class CollatzCompute : IChallengeCalculator
    {
        public CollatzCompute()
        {
            InitializeLookup();
        }
        #region Static Helpers
        static Dictionary<int, int> _CollatzLookup;
        static void InitializeLookup()
        {
            if(_CollatzLookup == null)
            {
                _CollatzLookup = new Dictionary<int, int>();

                // seed with powers of 2.
                // 2^p has a cycle length of p+1.
                // 16 = 2^4: {16, 8, 4, 2, 1}

                for (int i = 1; i <= MAX_EXPONENT; i++)
                {
                    // Slightly faster than Math.Pow()
                    _CollatzLookup.Add(1 << i, i + 1);
                }
            }
        }
        const int MAX_EXPONENT = 24;
        const int MILLION = 1000000;

        static bool CheckNumber(int num)
        {
            return num > 0 && num <= MILLION;
        }

        static int f(int num)
        {
            if (num % 2 == 0)
            {
                return num / 2;
            }
            else if (num == 1)
            {
                return 1;
            }
            else
            {
                return 3 * num + 1;
            }
        }
        #endregion

        public abstract long ComputeCycleLength(long num);



        public abstract long CalculateMaxCycles(Input input);
        
    }
}
