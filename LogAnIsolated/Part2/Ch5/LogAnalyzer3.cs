namespace LogAnIsolated.Ch5 {
    public class LogAnalyzer3 {
        private ILogger myLogger;
        private IWebService myWebService;
        public int MinNameLength { get; set; }

        public LogAnalyzer3(ILogger logger, IWebService wService) {
            this.myLogger = logger;
            this.myWebService = wService;
        }

        public void Analyze(string fileName) {
            if (fileName.Length < MinNameLength) {
                try {
                    myLogger.LogError(string.Format("Filename too short: {0}", fileName));
                } catch (Exception e) {
                    myWebService.Write(new ErrorInfo {
                        Severity = 1000,
                        Message = e.Message
                    });
                }
            }
        }
    }
}