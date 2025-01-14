using LogAn.ch3;

namespace LogAn.ch3.UnitTests {
    
    [TestFixture]
    public class LogAnalyzerUsingFactoryMethodTests { 
        [Test]
        public void overrideTest() {
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.WillBeValid = true;

            TestableLogAnalyzer logAn = new TestableLogAnalyzer(stub);

            bool result = logAn.IsValidLogFileName("file.ext");

            Assert.True(result);
        }
    }

    class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod {
        public IExtensionManager myManager;

        public TestableLogAnalyzer(IExtensionManager eManager) {
            myManager = eManager;
        }

        protected override IExtensionManager GetManager() {
            return myManager;
        }
    }
}