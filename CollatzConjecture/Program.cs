using CollatzConjecture.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzConjecture
{
    class Program
    {
        

        const int MAX_EXPONENT = 24;
        const int MILLION = 1000000;
        //const int MAX_ITERATIONS = 10000000; // Try 10 million iterations and then stop.
        private static string _fileOutLocation = ConfigurationManager.AppSettings["outputFileLocation"];
       // static Dictionary<int, int> _CollatzLookup;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            IUserInputOutput userInputOutput = new FileUserInputOutput(_fileOutLocation);
            IChallengeCalculator challengeCalculator = new Computer();
            var inputs = userInputOutput.ReadInput();
            var outputs = new HashSet<Output>();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var input in inputs)
            {
                var maxCycle = challengeCalculator.CalculateMaxCycles(input);
                outputs.Add(new Output
                {
                    Input = input,
                    MaxCycle = maxCycle
                });
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine("Completed");
            userInputOutput.PrintOutput(outputs);

            Console.WriteLine("Completed");
            Console.ReadLine();
        }

        
        

        
    }
}
