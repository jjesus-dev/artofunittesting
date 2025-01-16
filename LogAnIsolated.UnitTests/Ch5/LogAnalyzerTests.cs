using LogAnIsolated.Ch5;
using NSubstitute;

namespace LogAnIsolated.Ch5.UnitTests {
    
    [TestFixture]
    public class LogAnalyzerTests {

        [Test]
        public void Analyze_TooShortFileName_CallLogger() {
            // creates a mock object that you'll assert against at the end of the test
            ILogger myLogger = Substitute.For<ILogger>();
            LogAnalyzer myAnalyzer = new LogAnalyzer(myLogger);

            myAnalyzer.MinNameLength = 6;
            myAnalyzer.Analyze("a.txt");

            // sets expectation using NSubstitute's API
            myLogger.Received().LogError("Filename too short: a.txt");
        }

        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument() {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            // forces method call to return fake value
            fakeRules.IsValidLogFileName("strict.txt").Returns(true);

            Assert.IsTrue(fakeRules.IsValidLogFileName("strict.txt"));
        }
    }
}