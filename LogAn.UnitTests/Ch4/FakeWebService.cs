using LogAn.Ch4;

namespace LogAn.Ch4.UnitTests {
    public class FakeWebService : IWebService {
        public string? LastError;

        public void LogError(string message) {
            LastError = message;
        }
    }
}

