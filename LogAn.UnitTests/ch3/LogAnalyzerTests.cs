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

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse() {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillThrow = new Exception("this is fake");

            LogAnalyzer logAn = new LogAnalyzer(myFakeManager);
            bool result = logAn.IsValidLogFileName("anything.anyextension");
            Assert.False(result);
        }
    }

    internal class FakeExtensionManager : IExtensionManager {
        public bool WillBeValid = false;

        // convert `exception` to a maybe-null type to get rid of warning CS8625
        public Exception? WillThrow = null;

        public bool IsValid(string fileName) {
            if (WillThrow != null) {
                throw WillThrow;
            }

            return WillBeValid;
        }
    }
}