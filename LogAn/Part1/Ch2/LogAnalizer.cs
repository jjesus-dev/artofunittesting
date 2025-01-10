namespace LogAn {
    public class LogAnalizer {
        public bool IsValidLogFileName(string fileName) {
            if(string.IsNullOrEmpty(fileName)) {
                throw new ArgumentException("filename has to be provided");
            }

            if(!fileName.EndsWith(".SLF", 
                StringComparison.CurrentCultureIgnoreCase)) {
                return false;
            }

            // Changes the state of the system
            WasLastFileNameValid = true;

            return true;
        }

        public bool WasLastFileNameValid { get; set; }
    }
}