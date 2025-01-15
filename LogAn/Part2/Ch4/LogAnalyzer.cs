namespace LogAn.Ch4 {
    public class LogAnalyzer {
        private IWebService myService;

        public LogAnalyzer(IWebService wService) {
            this.myService = wService;
        }

        public void Analyze(string fileName) {
            if (fileName.Length < 8) {
                myService.LogError("Filename too short: " + fileName);
            }
        }
    }
}