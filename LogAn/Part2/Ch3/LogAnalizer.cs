namespace LogAn.ch3 {
    public class LogAnalizer {
        public bool IsValidLogFileName(string fileName) {
            FileExtensionManager fem = new FileExtensionManager();
            return fem.IsValid(fileName);
        }
    }
}