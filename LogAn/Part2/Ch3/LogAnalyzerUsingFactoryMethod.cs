namespace LogAn.Ch3 {
    public class LogAnalyzerUsingFactoryMethod { 
        public bool IsValidLogFileName(string fileName) {
            return this.IsValid(fileName);
        }

        protected virtual bool IsValid(string fileName) {
            FileExtensionManager eManager = new FileExtensionManager();

            // returns result from real dependency
            return eManager.IsValid(fileName);
        }
    }
}