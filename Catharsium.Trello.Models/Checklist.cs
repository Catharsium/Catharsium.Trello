using System.Collections.Generic;

namespace Catharsium.Trello.Models
{
    public class Checklist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IdBoard { get; set; }
        public string IdCard { get; set; }

        public decimal Pos { get; set; }

        // limits
        //public object CreationMethod { get; set; }
        public List<CheckItem> CheckItems { get; set; }
    }
}