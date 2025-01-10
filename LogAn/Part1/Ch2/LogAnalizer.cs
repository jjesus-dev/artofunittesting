namespace LogAn {
    public class LogAnalizer {
        public bool IsValidLogFileName(string fileName) {
            if(!fileName.EndsWith(".SLF", 
                StringComparison.CurrentCultureIgnoreCase)) {
                return false;
            }

            return true;
        }

        public bool IsEmptyFileName(string fileName) {
            if(string.IsNullOrEmpty(fileName)) {
                throw new ArgumentException("filename has to be provided");
            }

            return true;
        }
    }
}