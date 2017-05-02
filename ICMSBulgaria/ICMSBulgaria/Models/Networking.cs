using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICMSBulgaria.Models
{
    public class Networking
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
    }
}