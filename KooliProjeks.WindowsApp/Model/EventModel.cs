namespace KooliProjeks.WindowsApp.Model
{
    public class EventModel
    {
        public int Id { get; set; }
        public string event_name { get; set; }
        public DateTime event_date_start { get; set; }
        public DateTime event_date_end { get; set; }
        public string event_description { get; set; } // Events program
        public string user_Id { get; set; }
        public int MaxParticipants { get; set; }
        public int? event_price { get; set; }
    }
}