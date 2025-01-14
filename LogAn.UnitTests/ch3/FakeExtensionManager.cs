using LogAn.ch3;

namespace LogAn.ch3.UnitTests {
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