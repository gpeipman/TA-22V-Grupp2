using System.Collections.ObjectModel;
using System.ComponentModel;
using KooliProjektMVVM.shared.ApiClient;

namespace KooliProjektMVVM
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IEventApiClient _apiClient;
        private EventModel _selectedItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<EventModel> Lists { get; set; }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand NewCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }

        public MainWindowViewModel(IEventApiClient apiClient)
        {
            _apiClient = apiClient;

            Lists = new ObservableCollection<EventModel>();

            SaveCommand = new RelayCommand(
                p => true,
                p => { _apiClient.Save(SelectedItem); UpdateLists(); }
            );

            NewCommand = new RelayCommand(
                p => true,
                p => SelectedItem = new EventModel()
            );

            DeleteCommand = new RelayCommand(
                p => SelectedItem != null,
                p => { _apiClient.Delete(SelectedItem.Id); UpdateLists(); }
            );

            UpdateLists();
        }

        public EventModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged(nameof(SelectedItem));
            }
        }

        private void UpdateLists()
        {
            Lists.Clear();

            var lists = _apiClient.List() ?? new List<EventModel>();

            foreach (var item in lists)
            {
                Lists.Add(item);
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}