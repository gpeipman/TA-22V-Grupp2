using KooliProjektMVP.shared.ApiClient;
using KooliProjektMVP.shared.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjektMVP.shared.Presenter
{
    public class EventPresenter
    {
        private readonly IEventView _view;
        private readonly IEventApiClient _apiClient;

        private EventModel _selectedItem;

        public EventPresenter(IEventView view, IEventApiClient apiClient)
        {
            _view = view;
            _view.Presenter = this;

            _apiClient = apiClient;

            LoadLists(); 
        }

        public EventPresenter(IEventView view)
        {
            _view = view;
        }

        private void LoadLists()
        {
            _view.Lists = _apiClient.List();
        }

        public void SelectItem(EventModel selectedItem)
        {
            _selectedItem = selectedItem;

            if (_selectedItem == null)
            {
                _view.SelectedEventId = 0;
                _view.SelectedItemName = "";
                _view.Selected_event_date_start = default(DateTime);
                _view.Selected_event_date_end = default(DateTime);
                _view.Selected_event_description = "";
                _view.Selected_user_Id = "";
                _view.Selected_MaxParticipants = 0;
                _view.Selected_event_price = 0;
            }
            else
            {
                _view.SelectedEventId = _selectedItem.Id;
                _view.SelectedItemName = _selectedItem.event_name;
                _view.Selected_event_date_start = _selectedItem.event_date_start;
                _view.Selected_event_date_end = _selectedItem.event_date_end;
                _view.Selected_event_description = _selectedItem.event_description;
                _view.Selected_user_Id = _selectedItem.user_Id;
                _view.Selected_MaxParticipants = _selectedItem.MaxParticipants;
                _view.Selected_event_price = _selectedItem.event_price;
            }
        }

        public void Save()
        { 
            var list = _selectedItem;
            if (list == null)
            {
                list = new EventModel();
            }

            list.event_name = _view.SelectedItemName;
            list.event_date_start = _selectedItem.event_date_start;
            list.event_date_end = _selectedItem.event_date_end;
            list.event_description = _selectedItem.event_description;
            list.user_Id = _selectedItem.user_Id;
            list.MaxParticipants = _selectedItem.MaxParticipants;
            list.event_price = _selectedItem.event_price;

            _apiClient.Save(list);

            LoadLists();
        }

        public void Delete()
        {
            _apiClient.Delete(_view.SelectedEventId);

            LoadLists();
        }
    }
}
