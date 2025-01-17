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
            FakeWebService mockWebService = new FakeWebService();

            FakeLogger2 stubLogger = new FakeLogger2();
            stubLogger.WillThrow = new Exception("fake exception");

            var myAnalyzer2 = new LogAnalyzer2(stubLogger, mockWebService);
            myAnalyzer2.MinNameLength = 8;

            string tooShortFileName = "abc.ext";
            myAnalyzer2.Analyze(tooShortFileName);

            Assert.That(mockWebService.MessageToWebService, Does.Contain("fake exception"));
        }
    }
}