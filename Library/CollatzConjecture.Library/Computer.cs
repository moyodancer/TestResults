using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzConjecture.Library
{
    public class Computer : CollatzCompute
    {
        private static Dictionary<long, long> remember = new Dictionary<long, long>();

        public override long CalculateMaxCycles(Input input)
        {
            long max = 0;
            long len;
            for(long i = input.Start; i<input.End; i++)
            {
                len = ComputeCycleLength(i);
                if (max < len)
                    max = len;

            }
            return max;
        }

        public override long ComputeCycleLength(long num)
        {
            long count = 1;
            long original = num;
            while (num != 1)
            {
                if (remember.ContainsKey(num))
                {
                    if(original != num) 
                    {
                        remember.Add(original, count + remember[num] - 1); 
                        return count + remember[num] - 1;
                    }
                    else
                    {
                        return remember[original];
                    }
                }
                else {
                    if (num % 2 == 0)
                    {
                        num /= 2;
                    }
                    else
                    {
                        num = (3 * num + 1)/2;
                        count++;
                    }
                }
                count++;
            }
            if(!remember.ContainsKey(original))
                remember.Add(original, count);
            return count;
        }
    }
}
