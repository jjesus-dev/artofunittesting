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
            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);

            Assert.IsTrue(fakeRules.IsValidLogFileName("strict.txt"));
        }

        [Test]
        public void Returns_ArgAny_Throws() {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();
            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>()))
                .Do(context => { throw new Exception ("fake exception"); });

            Assert.Throws<Exception>(() => fakeRules.IsValidLogFileName("anything"));
        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebService() {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();

            // simulates an exception on any input
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception"); });

            var myAnalyzer2 = new LogAnalyzer2(stubLogger, mockWebService);
            myAnalyzer2.MinNameLength = 10;
            myAnalyzer2.Analyze("abc.ext");

            // checks that the mock web service was called with a string containing "fake exception"
            mockWebService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObject() {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When(logger => logger.LogError(Arg.Any<string>())).
                Do(info => { throw new Exception("fake exception"); });

            var myAnalyzer3 = new LogAnalyzer3(stubLogger, mockWebService);
            myAnalyzer3.MinNameLength = 10;
            myAnalyzer3.Analyze("Short.txt");

            // strongly typed argument matcher
            // plus a simple "and" operator to create a more complex condition
            mockWebService.Received().Write(Arg.Is<ErrorInfo>(
                info => info.Severity == 1000 && 
                info.Message.Contains("fake exception")));
        }
    }
}