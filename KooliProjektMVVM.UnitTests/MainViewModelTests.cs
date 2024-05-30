using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KooliProjektMVVM.shared.ApiClient;
using Moq;

namespace KooliProjektMVVM.UnitTests
{
    public class MainViewModelTests
    {
        private readonly Mock<IEventApiClient> _apiClientMock;
        private readonly MainWindowViewModel _viewModel;

        public MainViewModelTests()
        {
            _apiClientMock = new Mock<IEventApiClient>();
            _viewModel = new MainWindowViewModel(_apiClientMock.Object);
        }

        [Fact]
        public void ViewModel_loads_data_when_created()
        {
            // Arrange
            IList<EventModel> lists = new List<EventModel>();
            _apiClientMock.Setup(c => c.List())
                          .Returns(lists)
                          .Verifiable();

            // Act
            new MainWindowViewModel(_apiClientMock.Object);

            // Assert
            _apiClientMock.VerifyAll();
        }

        [Fact]
        public void SelectedItem_returns_correct_item()
        {
            // Arrange
            var item = new EventModel();

            // Act
            _viewModel.SelectedItem = item;

            // Assert
            Assert.Equal(item, _viewModel.SelectedItem);
        }

        [Fact]
        public void DeleteCommand_is_disabled_when_selected_item_is_missing()
        {
            // Arrange
            var prm = new object();

            // Act
            _viewModel.SelectedItem = null;

            // Assert
            Assert.False(_viewModel.DeleteCommand.CanExecute(prm));
        }

        [Fact]
        public void DeleteCommand_is_enabled_when_item_is_selected()
        {
            // Arrange
            var item = new EventModel();
            var prm = new object();

            // Act
            _viewModel.SelectedItem = item;

            // Assert
            Assert.True(_viewModel.DeleteCommand.CanExecute(prm));
        }

        [Fact]
        public void DeleteCommand_deletes_selected_item_and_updates_list()
        {
            // Arrange
            var item = new EventModel { Id = 10 };
            var prm = new object();
            _apiClientMock.Setup(c => c.Delete(item.Id)).Verifiable();
            _apiClientMock.Setup(c => c.List()).Verifiable();

            // Act
            _viewModel.SelectedItem = item;
            _viewModel.DeleteCommand.Execute(prm);

            // Assert
            _apiClientMock.VerifyAll();
        }
    }
}
