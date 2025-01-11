namespace LogAn.ch3 {
    public class LogAnalizer {
        public bool IsValidLogFileName(string fileName) {
            IExtensionManager emngr = new FileExtensionManager();
            return emngr.IsValid(fileName);
        }
    }
}