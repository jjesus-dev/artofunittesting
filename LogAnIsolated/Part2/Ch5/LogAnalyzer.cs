namespace LogAnIsolated.Ch5 {
    public class LogAnalyzer {
        private ILogger myLogger;
        public int MinNameLength { get; set; }

        public LogAnalyzer(ILogger logger) {
            this.myLogger = logger;
        }

        public void Analyze(string fileName) {
            if (fileName.Length < MinNameLength) {
                myLogger.LogError("Filename too short: " + fileName);
            }
        }
    }
}