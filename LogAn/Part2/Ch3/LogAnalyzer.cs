namespace LogAn.Ch3 {
    public class LogAnalyzer {
        private IExtensionManager eManager;

        public LogAnalyzer() {
            eManager = ExtensionManagerFactory.Create();
        }

        public IExtensionManager ExtensionManager {
            get { return eManager; }
            set { eManager = value; }
        }

        public bool IsValidLogFileName(string fileName) {
            return eManager.IsValid(fileName);
        }
    }
}