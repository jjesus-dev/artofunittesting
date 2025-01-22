namespace LogAnIsolated.Ch5 {
    public interface IView {
        event Action Loaded;
        void Render(string text);
    }
}