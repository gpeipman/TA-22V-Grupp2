using Moq;
using KooliProjektMVP.shared.ApiClient;
using KooliProjektMVP.shared.ViewInterfaces;
using KooliProjektMVP.shared.Presenter;

namespace KooliProjektMVP.Tests
{
    public class EventPresenterTests : IDisposable
    {
        private readonly Mock<IEventView> _viewMock;
        private readonly Mock<IEventApiClient> _apiClientMock;
        private readonly EventPresenter _presenter;

        public EventPresenterTests()
        {
            _viewMock = new Mock<IEventView>();
            _apiClientMock = new Mock<IEventApiClient>();

            _presenter = new EventPresenter(_viewMock.Object, _apiClientMock.Object);
        }

        [Fact]
        public void Presenter_should_load_list()
        {
            // Arrange
            _apiClientMock.Setup(c => c.List())
                          .Returns(new List<EventModel>())
                          .Verifiable();

            // Act
            var presenter = new EventPresenter(_viewMock.Object, _apiClientMock.Object);

            // Assert
            _apiClientMock.VerifyAll();
        }

        [Fact]
        public void Presenter_should_select_null_item()
        {
            // Arrange
            _viewMock.SetupSet(x => x.SelectedEventId = 0).Verifiable();
            _viewMock.SetupSet(x => x.SelectedItemName = "").Verifiable();
            _viewMock.SetupSet(x => x.SelectedItemName = "").Verifiable();
            _viewMock.SetupSet(x => x.Selected_event_date_start = default(DateTime)).Verifiable();
            _viewMock.SetupSet(x => x.Selected_event_date_end = default(DateTime)).Verifiable();
            _viewMock.SetupSet(x => x.Selected_event_description = "").Verifiable();
            _viewMock.SetupSet(x => x.Selected_user_Id = "").Verifiable();
            _viewMock.SetupSet(x => x.Selected_event_price = 0).Verifiable();


            // Act
            _presenter.SelectItem(null);

            // Assert
            _viewMock.VerifyAll();
        }

        [Fact]
        public void Presenter_should_select_list()
        {
            // Arrange
            var model = new EventModel {
                Id = 1, 
                event_name = "Test",
                event_date_start = DateTime.Now,
                event_date_end = DateTime.Now,
                event_description = "Test",
                user_Id = "1234567",
                MaxParticipants = 2,
                event_price = 10
            };
            _viewMock.SetupSet(x => x.SelectedEventId = model.Id).Verifiable();
            _viewMock.SetupSet(x => x.SelectedItemName = model.event_name).Verifiable();
            _viewMock.SetupSet(x => x.Selected_event_date_start = model.event_date_start).Verifiable();
            _viewMock.SetupSet(x => x.Selected_event_date_end = model.event_date_end).Verifiable();
            _viewMock.SetupSet(x => x.Selected_event_description = model.event_description).Verifiable();
            _viewMock.SetupSet(x => x.Selected_user_Id = model.user_Id).Verifiable();
            _viewMock.SetupSet(x => x.Selected_MaxParticipants = model.MaxParticipants).Verifiable();
            _viewMock.SetupSet(x => x.Selected_event_price = model.event_price).Verifiable();


            // Act
            _presenter.SelectItem(model);

            // Assert
            _viewMock.VerifyAll();
        }

        [Fact]
        public void Presenter_should_save_existing_list()
        {
            // Arrange
            var model = new EventModel
            {
                Id = 1,
                event_name = "Test",
                event_date_start = DateTime.Now,
                event_date_end = DateTime.Now,
                event_description = "Test",
                user_Id = "1234567",
                MaxParticipants = 2,
                event_price = 10
            };
            var expectedTitle = "Def";
            _viewMock.SetupGet(x => x.SelectedItemName).Returns(expectedTitle).Verifiable();
            _apiClientMock.Setup(x => x.Save(model)).Verifiable();
            _apiClientMock.Setup(x => x.List()).Verifiable();

            // Act
            _presenter.SelectItem(model);
            _presenter.Save();

            // Assert
            Assert.Equal(expectedTitle, model.event_name);
            _viewMock.VerifyAll();
        }

        [Fact]
        public void Presenter_should_delete_list()
        {
            // Arrange
            var list = new EventModel { Id = 10 };
            _viewMock.SetupGet(x => x.SelectedEventId).Returns(list.Id).Verifiable();
            _apiClientMock.Setup(x => x.Delete(list.Id)).Verifiable();
            _apiClientMock.Setup(x => x.List()).Verifiable();

            // Act
            _presenter.SelectItem(list);
            _presenter.Delete();

            // Assert
            _viewMock.VerifyAll();
        }

        public void Dispose()
        {
            _apiClientMock.Object.Dispose();
        }
    }
}