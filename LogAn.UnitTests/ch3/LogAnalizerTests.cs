using LogAn.ch3;

namespace LogAn.ch3.UnitTests {
    
    [TestFixture]
    public class LogAnalyzerTests {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnTrue() {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;

            LogAnalyzer logAn = new LogAnalyzer(myFakeManager);

            bool result = logAn.IsValidLogFileName("short.ext");
        }
    }

    internal class FakeExtensionManager : IExtensionManager {
        public bool WillBeValid = false;

        public bool IsValid(string fileName) {
            return WillBeValid;
        }
    }
}