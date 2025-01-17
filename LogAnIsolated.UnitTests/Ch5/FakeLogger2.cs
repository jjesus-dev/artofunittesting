using LogAnIsolated.Ch5;

namespace LogAnIsolated.Ch5.UnitTests { 
    public class FakeLogger2 : ILogger {
        public Exception? WillThrow;
        public string? LoggerGotMessage;

        public void LogError(string message) {
            LoggerGotMessage = message;

            if (WillThrow != null) {
                throw WillThrow;
            }
        }
    }
}