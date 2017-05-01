using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICMSBulgaria.Models
{
    public class Speaker
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Possition { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }
}