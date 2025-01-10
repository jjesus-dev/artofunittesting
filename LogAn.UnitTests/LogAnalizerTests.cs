using LogAn;

namespace LogAn.UnitTests {

    [TestFixture]
    public class LogAnalizerTests {
        private LogAnalizer analizer;

        [SetUp]
        public void SetUp() {
            analizer = new LogAnalizer();
        }

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse() {
            bool result = analizer.IsValidLogFileName("filewithbadextension.foo");
            Assert.False(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtension_ReturnsTrue() {
            bool result = analizer.IsValidLogFileName("filewithbadextension.slf");
            Assert.True(result);
        }

        [TestCase("filewithbadextension.SLF")]
        [TestCase("filewithbadextension.slf")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file) {
            bool result = analizer.IsValidLogFileName(file);
            Assert.True(result);
        }
    }
}