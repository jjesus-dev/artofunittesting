namespace LogAnIsolated.Ch5 {
    public interface IView {
        event Action Loaded;
        event Action<string> ErrorOcurred;
        void Render(string text);
    }
}