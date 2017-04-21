using System;
using System.Collections.Generic;
using System.Text;

namespace ICMSBulgaria.Models
{
    public class News
    {
        public News()
        {
            ID = "";
        }

        public string ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return string.Format("[News: Title={0}, Content={1}]", Title, Content);
        }
    }
}
