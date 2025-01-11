namespace LogAn.ch3 {
    public class LogAnalyzer {
        private IExtensionManager eManager;

        public LogAnalyzer(IExtensionManager mngr) {
            eManager = mngr;
        }

        public bool IsValidLogFileName(string fileName) {
            return eManager.IsValid(fileName);
        }
    }
}