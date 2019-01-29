using System;
using System.Collections.Generic;

namespace Northwind.Domain.Entities
{
    public class Room
    {
        public string Id { get; set; }
        public string Size { get; set; }
        public string ClientName { get; set; }
        public List<DateTime> RentedCalendar { get; set; }
        public string ClientPhone { get; set; }
        public string ClientMail { get; set; }
    }
}
