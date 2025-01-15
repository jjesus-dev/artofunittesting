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

            // creating and expected object
            EmailInfo expectedEmail = new EmailInfo {
                To = "someone@somewhere.com",
                Body = "fake exception",
                Subject = "can't log"
            };

            Assert.That(mockEmail.email, Is.EqualTo(expectedEmail));

            // if you have a reference to the actual object you expect as an end result, use this instead
            //Assert.That(mockEmail.email, Is.SameAs(expectedEmail));
        }
    }
}