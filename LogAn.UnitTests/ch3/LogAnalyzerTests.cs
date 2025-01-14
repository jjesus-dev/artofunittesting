using LogAn.ch3;

namespace LogAn.ch3.UnitTests {
    
    [TestFixture]
    public class LogAnalyzerTests {
        [Test]
        public void IsValidFileName_SupportedExtension_ReturnTrue() {
            // set up the stub to use, make sure it returns true
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;

            ExtensionManagerFactory.SetManager(myFakeManager);

            // create analyzer and inject stub
            LogAnalyzer logAn = new LogAnalyzer();
            logAn.ExtensionManager = myFakeManager;

            bool result = logAn.IsValidLogFileName("short.ext");
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse() {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillThrow = new Exception("this is fake");

            LogAnalyzer logAn = new LogAnalyzer();
            logAn.ExtensionManager = myFakeManager;
            bool result = logAn.IsValidLogFileName("anything.anyextension");
            Assert.False(result);
        }
    }
}