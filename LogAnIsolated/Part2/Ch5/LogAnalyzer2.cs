namespace LogAnIsolated.Ch5 {
    public class LogAnalyzer2 {
        private ILogger myLogger;
        private IWebService myWebService;
        public int MinNameLength { get; set; }

        public LogAnalyzer2(ILogger logger, IWebService wService) {
            this.myLogger = logger;
            this.myWebService = wService;
        }

        public void Analyze(string fileName) {
            if (fileName.Length < MinNameLength) {
                try {
                    myLogger.LogError(string.Format("Filename too short: {0}", fileName));
                } catch (Exception e) {
                    myWebService.Write("Error from Logger: " + e);
                }
            }
        }
    }
}