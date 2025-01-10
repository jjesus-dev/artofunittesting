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
        [Category("Fluent Syntax")]
        public void IsValidFileName_EmptyFileName_ThrowsFluent() {
            var ex = Assert.Catch<ArgumentException>(() => analizer.IsValidLogFileName(""));

            Assert.That(ex.Message, Does.Contain("filename has to be provided"));
        }

        [TestCase("filewithbadextension.SLF", true)]
        [TestCase("filewithbadextension.slf", true)]
        [TestCase("filewithbadextension.foo", false)]
        public void IsValidLogFileName_VariousExtensions_ChecksThem(string file, bool expected) {
            bool result = analizer.IsValidLogFileName(file);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("filewithbadextension.SLF")]
        [TestCase("filewithbadextension.slf")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file) {
            bool result = analizer.IsValidLogFileName(file);
            Assert.True(result);
        }
    }
}