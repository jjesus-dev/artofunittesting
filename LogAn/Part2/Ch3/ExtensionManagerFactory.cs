using LogAn.ch3;

namespace LogAn.ch3.UnitTests {
    class ExtensionManagerFactory {
        private static IExtensionManager? customManager = null;

        public static IExtensionManager Create() {
            if (customManager != null) {
                return customManager;
            }

            return new FileExtensionManager();
        }

        public static void SetManager(IExtensionManager eManager) {
            customManager = eManager;
        }
    }
}