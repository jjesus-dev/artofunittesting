using LogAn.Ch4;

namespace LogAn.Ch4.UnitTests {
    public class FakeEmailService : IEmailService {
        public string? To;
        public string? Subject;
        public string? Body;

        public void SendEmail(string to, string subject, string body) {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
