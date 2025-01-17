namespace LogAnIsolated.Ch5 {
    public class ErrorInfo {
        public int Severity { get; set; }
        // to get rid of the dereference warning 
        // because "Message" could be `NULL`
        public string Message { get; set; } = string.Empty;
    }
}