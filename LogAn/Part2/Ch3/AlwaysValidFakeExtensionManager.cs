namespace LogAn.Ch3 {
    public class AlwaysValidFakeExtensionManager : IExtensionManager {
        public bool IsValid(string fileName) {
            return true;
        }
    }
}