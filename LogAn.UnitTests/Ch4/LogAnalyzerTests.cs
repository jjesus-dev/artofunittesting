using LogAn.Ch4;

namespace LogAn.Ch4.UnitTests {
    
    [TestFixture]
    public class LogAnalyzerTests {

        [Test]
        public void Analyze_TooShortFileName_CallsWebService() {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzer logAn = new LogAnalyzer(mockService);
            string tooShortFileName = "abc.ext";

            logAn.Analyze(tooShortFileName);
            Assert.That(mockService.LastError, Does.Contain("Filename too short: abc.ext"));
        }        
    }
}