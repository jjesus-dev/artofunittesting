using LogAn.Ch4;

namespace LogAn.Ch4.UnitTests {
    
    [TestFixture]
    public class LogAnalyzer2Tests {

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail() {
            FakeWebService stubService = new FakeWebService();
            stubService.ToThrow = new Exception("fake exception");
            
            FakeEmailService mockEmail = new FakeEmailService();
            
            LogAnalyzer2 logAn2 = new LogAnalyzer2(stubService, mockEmail);
            string tooShortFileName = "abc.ext";

            logAn2.Analyze(tooShortFileName);
            Assert.That(mockEmail.To, Does.Contain("someone@somewhere.com"));
            Assert.That(mockEmail.Body, Does.Contain("fake exception"));
            Assert.That(mockEmail.Subject, Does.Contain("can't log"));
        }        
    }
}