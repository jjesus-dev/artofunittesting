namespace LogAnIsolated.Ch5 {
    public class Presenter {
        private readonly IView myView;
        private ILogger? myLogger;

        public Presenter(IView view) {
            myView = view;
            this.myView.Loaded += OnLoaded;
        }

        public Presenter(IView view, ILogger logger) {
            myView = view;
            myLogger = logger;
            this.myView.Loaded += OnLoaded;
            this.myView.ErrorOcurred += OnLoaded;
        }

        private void OnLoaded() {
            myView.Render("Hello World");
        }

        private void OnLoaded(string message) {
            myLogger?.LogError(message);
        }
    }
}