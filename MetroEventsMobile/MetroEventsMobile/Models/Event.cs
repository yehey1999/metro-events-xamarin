using System;
using System.Collections.Generic;
using System.Text;

namespace MetroEventsMobile.Models
{
    public class Event
    {
        public int id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string startDatetime { get; set; }

        public string endDatetime { get; set; }

        public string status { get; set; }

        public string address { get; set; }

        public string createdAt { get; set; }

        public List<User> participants { get; set; }

        public List<Request> requests { get; set; }

        public List<Review> reviews { get; set; }

    }
}
