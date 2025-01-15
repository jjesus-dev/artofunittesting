using LogAn.Ch4;

namespace LogAn.Ch4.UnitTests {
    public class FakeEmailService : IEmailService {
        public EmailInfo? email = null;

        public void SendEmail(EmailInfo emailInfo) {
            email = emailInfo;
        }
    }
}

