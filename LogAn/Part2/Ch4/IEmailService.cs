namespace LogAn.Ch4 {
    public interface IEmailService {
        void SendEmail(string to, string subject, string body);
    }
}