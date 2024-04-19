using KooliProjektMVP.shared.ApiClient;
using KooliProjektMVP.shared.Presenter;
using KooliProjektMVP.shared.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KooliProjeks.WindowsApp
{
    public partial class EventForm : Form, IEventView
    {
        private readonly IEventView _view;
        private readonly IEventApiClient _apiClient;
        public IList<EventModel> Lists 
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public int SelectedEventId { get; set; }
        public string SelectedItemName { get; set; }
        public DateTime Selected_event_date_start { get; set; }
        public DateTime Selected_event_date_end { get; set; }
        public string Selected_event_description { get; set; }
        public string Selected_user_Id { get; set; }
        public int Selected_MaxParticipants { get; set; }
        public int? Selected_event_price { get; set; }
        EventPresenter IEventView.Presenter { set => _view.Presenter = value; }

        public EventPresenter Presenter;

        public EventForm()
        {
            Presenter = new EventPresenter(_view, _apiClient);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}