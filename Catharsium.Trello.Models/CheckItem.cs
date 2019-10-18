namespace Catharsium.Trello.Models
{
    public class CheckItem
    {
        public string IdChecklist { get; set; }
        public string State { get; set; }
        public string Id { get; set; }

        public string Name { get; set; }

        //public object NameData { get; set; }
        public decimal Pos { get; set; }
    }
}