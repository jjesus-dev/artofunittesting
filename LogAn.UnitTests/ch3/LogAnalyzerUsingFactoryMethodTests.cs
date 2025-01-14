using LogAn.ch3;

namespace LogAn.ch3.UnitTests {
    
    [TestFixture]
    public class LogAnalyzerUsingFactoryMethodTests { 
        [Test]
        public void overrideTestWithoutStub() {
            TestableLogAnalyzer logAn = new TestableLogAnalyzer();
            // sets fake result value
            logAn.IsSupported = true;

            bool result = logAn.IsValidLogFileName("file.ext");
            Assert.True(result);
        }
    }

    class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod {
        public bool IsSupported;

        // returns fake value that was set by the test
        protected override bool IsValid(string fileName) {
            return IsSupported;
        }
    }
}