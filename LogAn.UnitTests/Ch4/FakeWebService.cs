using LogAn.Ch4;

namespace LogAn.Ch4.UnitTests {
    public class FakeWebService : IWebService {
        public Exception? ToThrow;
        public string? LastError;

        public void LogError(string message) {
            if (ToThrow != null) {
                throw ToThrow;
            }
            
            LastError = message;
        }
    }
}

