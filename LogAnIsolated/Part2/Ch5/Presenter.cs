namespace LogAnIsolated.Ch5 {
    public class Presenter {
        private readonly IView myView;

        public Presenter(IView view) {
            myView = view;
            this.myView.Loaded += OnLoaded;
        }

        private void OnLoaded() {
            myView.Render("Hello World");
        }
    }
}