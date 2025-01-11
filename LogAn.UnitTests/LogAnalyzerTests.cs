using LogAn;

namespace LogAn.UnitTests {

    [TestFixture]
    public class LogAnalyzerTests {
        private LogAnalyzer analyzer;

        [SetUp]
        public void SetUp() {
            analyzer = new LogAnalyzer();
        }

        [Test]
        [Category("Fluent Syntax")]
        public void IsValidFileName_EmptyFileName_ThrowsFluent() {
            var ex = Assert.Catch<ArgumentException>(() => analyzer.IsValidLogFileName(""));

            Assert.That(ex.Message, Does.Contain("filename has to be provided"));
        }

        [TestCase("filewithbadextension.SLF", true)]
        [TestCase("filewithbadextension.slf", true)]
        [TestCase("filewithbadextension.foo", false)]
        public void IsValidLogFileName_VariousExtensions_ChecksThem(string file, bool expected) {
            bool result = analyzer.IsValidLogFileName(file);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("filewithbadextension.SLF")]
        [TestCase("filewithbadextension.slf")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file) {
            bool result = analyzer.IsValidLogFileName(file);
            Assert.True(result);
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected) {
            analyzer.IsValidLogFileName(file);
            Assert.That(analyzer.WasLastFileNameValid, Is.EqualTo(expected));
        }
    }
}