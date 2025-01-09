namespace LogAn {
    public class LogAnalizer {
        public bool IsValidLogFileName(string fileName) {
            if(!fileName.EndsWith(".SLF", 
                StringComparison.CurrentCultureIgnoreCase)) {
                return false;
            }

            return true;
        }
    }
}