using MediatR;
using System;
using System.Collections.Generic;

namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest
    {
        public string Id { get; set; }
        public string Size { get; set; }
        public string ClientName { get; set; }
        public List<DateTime> RentedCalendar { get; set; }
        public string ClientPhone { get; set; }
        public string ClientMail { get; set; }
    }
}