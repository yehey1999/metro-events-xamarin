using System;
using System.Collections.Generic;
using System.Text;

namespace MetroEventsMobile.Models
{
    public class User
    {
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string type { get; set; }

        public string grantedAt { get; set; }

        public List<Event> events { get; set; }

        public List<Event> createdEvents { get;  set; }

        public List<Request> sentRequests { get; set; }

        // public Event[] events { get; set; }

        // public Event[] createdEvent { get; set; }

        // public Request[] sentRequest { get; set; }

    }
}
