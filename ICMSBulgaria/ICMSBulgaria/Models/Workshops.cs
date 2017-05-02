using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICMSBulgaria.Models
{
    public class Workshops
    {
        public Workshops()
        {
            ID = "";
        }

        public string ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}
