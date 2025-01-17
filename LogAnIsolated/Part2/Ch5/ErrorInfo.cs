namespace LogAnIsolated.Ch5 {
    public class ErrorInfo {
        public int Severity { get; set; }
        // to get rid of the dereference warning 
        // because "Message" could be `NULL`
        public string Message { get; set; } = string.Empty;

        // this are needed to make this test pass:
        // Analyze_LoggerThrows_CallsWebServiceWithNSubObjectCompare
        protected bool Equals(ErrorInfo other)
        {
            return Severity == other.Severity && string.Equals(Message, other.Message);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ErrorInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Severity*1000) ^ Message.GetHashCode();
            }
        }
    }
}