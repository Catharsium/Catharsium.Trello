﻿namespace Catharsium.Trello.Models
{
    public class List
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Closed { get; set; }
        public string IdBoard { get; set; }
        public decimal Pos { get; set; }
        public bool Subscribed { get; set; }
        //public object SoftLimit { get; set; }
        //limits
        //public object CreationMethod {get;set;}
    }
}