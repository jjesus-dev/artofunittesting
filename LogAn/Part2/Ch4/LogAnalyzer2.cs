namespace LogAn.Ch4 {
    public class LogAnalyzer2 {
        public IWebService myService {
            get; set;
        }

        public IEmailService myEmail {
            get; set;
        }

        public LogAnalyzer2(IWebService wService, IEmailService eMail) {
            this.myService = wService;
            this.myEmail = eMail;
        }

        public void Analyze(string fileName) {
            if (fileName.Length < 8) {
                try {
                    myService.LogError("Filename too short: " + fileName);
                } 
                catch (Exception e) {
                    myEmail.SendEmail("someone@somewhere.com", "can't log", e.Message);
                }
            }
        }
    }
}