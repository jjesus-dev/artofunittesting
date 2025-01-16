using LogAnIsolated.Ch5;

namespace LogAnIsolated.Ch5.UnitTests { 
    public class FakeLogger : ILogger {
        public string? LastError;

        public void LogError(string message) {
            LastError = message;
        }
    }
}