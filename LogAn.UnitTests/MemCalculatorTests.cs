using LogAn;

namespace LogAn.UnitTests { 

    [TestFixture]
    public class MemCalculatorTests {
        private MemCalculator calculator;

        [SetUp]
        public void SetUp() {
            calculator = new MemCalculator();
        }

        [Test]
        public void Sum_ByDefault_ReturnsZero() {
            int lastSum = calculator.Sum();

            Assert.That(lastSum, Is.EqualTo(0));
        }

        [Test]
        public void Add_WhenCalled_ChangesSum() {
            calculator.Add(1);
            int sum = calculator.Sum();

            Assert.That(sum, Is.EqualTo(1));
        }
    }
}