using KooliProjekt.Data;
using KooliProjektMVP.shared.ApiClient;
using KooliProjektMVP.shared.Presenter;
using KooliProjektMVP.shared.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KooliProjeks.WindowsApp
{
    public partial class EventForm : Form, IEventView
    {
        private readonly IEventView _view;
        private readonly IEventApiClient _apiClient;
        public IList<EventModel> Lists
        {
            get { return (IList<EventModel>)listBox1.DataSource; }
            set
            {
                listBox1.DataSource = value;
            }
        }
        public int SelectedEventId
        {
            get { return int.Parse(textBox1.Text); }
            set { textBox1.Text = value.ToString(); }
        }
        public string SelectedItemName
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public DateTime Selected_event_date_start
        {
            get
            {
                return DateTime.Parse(textBox3.Text);
            }
            set
            {
                textBox3.Text = value.ToString();
            }
        }
        public DateTime Selected_event_date_end
        {
            get
            {
                return DateTime.Parse(textBox4.Text);
            }
            set
            {
                textBox4.Text = value.ToString();
            }
        }

        public string Selected_event_description
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }
        public string Selected_user_Id
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; }
        }
        public int Selected_MaxParticipants
        {
            get { return int.Parse(textBox7.Text); }
            set { textBox7.Text = value.ToString(); }
        }

        public int? Selected_event_price
        {
            get
            {
                var price = int.Parse(textBox8.Text);
                return price;
            }
            set
            { textBox8.Text = value.ToString(); }
        }
        public EventPresenter Presenter { private get; set; }


        public EventForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            button1.Click += button1_Click;
            button2.Click += button2_Click;

            base.OnLoad(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kutsu presenteri SelectItem meetodi
            Presenter.SelectItem((EventModel)listBox1.SelectedItem);

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

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Presenter.Delete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.Save();
        }
    }
}