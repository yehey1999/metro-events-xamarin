using System;
using System.Collections.Generic;
using System.Text;

namespace MetroEventsMobile.Models
{
    public class Review
    {
        public int id { get; set; }

        public string comment { get; set; }

        public string createdAt { get; set; }

        public User user { get; set; }

        public Event _event { get; set; }

    }
}
