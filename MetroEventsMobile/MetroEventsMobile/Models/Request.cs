using System;
using System.Collections.Generic;
using System.Text;

namespace MetroEventsMobile.Models
{
    public class Request
    {
        public int id { get; set; }

        public string title { get; set; }

        public string details { get; set; }

        public string type { get; set; }

        public string status { get; set; }

        public string createdAt { get; set; }

        public string updatedAt { get; set; }

        public User sender { get; set; }

        public Event eventRequested { get; set; }

    }

}
