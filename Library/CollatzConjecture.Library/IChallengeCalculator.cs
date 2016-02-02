using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzConjecture.Library
{
    public interface IChallengeCalculator
    {
        /// <summary>
        /// Calculate max cycles for a given set of inputs. Standard 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        long CalculateMaxCycles(Input input);
        /// <summary>
        /// Compute the cycle length for an number using 3n + 1 algorithm
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        long ComputeCycleLength(long num);
    }
}
