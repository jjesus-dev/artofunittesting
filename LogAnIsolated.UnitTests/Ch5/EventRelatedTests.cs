using LogAnIsolated.Ch5;
using NSubstitute;

namespace LogAnIsolated.Ch5.UnitTests {
    
    [TestFixture]
    public class EventRelatedTests {
        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender() {
            var mockView = Substitute.For<IView>();

            // trigger the event with NSubstitute
            Presenter pres = new Presenter(mockView);
            mockView.Loaded += Raise.Event<Action>();

            // check that the view was called
            mockView.Received()
                .Render(Arg.Is<string>(s => s.Contains("Hello World")));
        }

        [Test]
        public void ctor_WhenViewHasError_CallsLogger() {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();

            // simulate the error
            Presenter pres = new Presenter(stubView, mockLogger);
            stubView.ErrorOcurred += Raise.Event<Action<string>>("fake error");

            // uses mock to check log call
            mockLogger.Received()
                .LogError(Arg.Is<string>(s => s.Contains("fake error")));
        }
    }
}