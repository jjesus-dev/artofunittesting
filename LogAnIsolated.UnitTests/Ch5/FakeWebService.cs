using LogAnIsolated.Ch5;

namespace LogAnIsolated.Ch5.UnitTests { 
    public class FakeWebService : IWebService {
        public string? MessageToWebService;

        public void Write(string message) {
            MessageToWebService = message;
        }
    }
}