using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICMSBulgaria.Models
{
    public class ProgramEvent
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}