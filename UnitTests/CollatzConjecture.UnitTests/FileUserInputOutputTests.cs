using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollatzConjecture.Library;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Configuration;

namespace CollatzConjecture.UnitTests
{
    [TestClass]
    public class FileUserInputOutputTests
    {
        private string _fileOutLocation = ConfigurationManager.AppSettings["outputFileLocation"];
        [TestMethod]
        public void ReadFromFileInAppConfigTest()
        {
            var fileReader = new FileUserInputOutput(_fileOutLocation);

            var inputs = fileReader.ReadInput();
            IEnumerable<Input> expected = new HashSet<Input>
            {
                new Input
                {
                    Start = 1,
                    End = 10
                }
            };
            
            
            CollectionAssert.AreEqual(expected.ToList(), inputs.ToList());
        }

        [TestMethod]
        public void WriteToFileTest()
        {
            var fileWriter = new FileUserInputOutput(_fileOutLocation);

            var outputs = new HashSet<Output>
            {
                new Output
                {
                    Input = new Input
                    {
                        Start = 1,
                        End = 10
                    },
                    MaxCycle = 20
                }
            };

            fileWriter.PrintOutput(outputs);

            Assert.IsTrue(File.Exists(_fileOutLocation));
            //should add additional checks that read the file and compare to expected outputs

        }

        [TestMethod]
        public void CalculateCyclesLengthTest()
        {
            long input = 22;
            long output = 16;
            IChallengeCalculator myComp = new Computer();
            long actual = myComp.ComputeCycleLength(input);
            Assert.AreEqual(output, actual);

            input = 19;
            output = 21;
            actual = myComp.ComputeCycleLength(input);
            Assert.AreEqual(output, actual);

            input = 22;
            output = 16;
            actual = myComp.ComputeCycleLength(input);
            Assert.AreEqual(output, actual);

            input = 38;
            output = 22;
            actual = myComp.ComputeCycleLength(input);
            Assert.AreEqual(output, actual);

            input = 44;
            output = 17;
            actual = myComp.ComputeCycleLength(input);
            Assert.AreEqual(output, actual);

        }
        [TestMethod]
        public void CalculateMaxCyclesTest()
        {
            Input myInput = new Input
            {
                Start = 1,
                End = 10
            };
            long output = 20;
            IChallengeCalculator myComp = new Computer();
            long actual = myComp.CalculateMaxCycles(myInput);

            Assert.AreEqual(output, actual);

        }
    }
}
