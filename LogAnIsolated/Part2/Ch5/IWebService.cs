namespace LogAnIsolated.Ch5 {
    public interface IWebService {
        void Write(string message);

        void Write(ErrorInfo errorInfo);
    }
}