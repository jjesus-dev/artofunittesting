using LogAn.Ch3;

namespace LogAn.Ch3 {
    public class ExtensionManagerFactory {
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