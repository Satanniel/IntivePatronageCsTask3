using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Northwind.Domain.Entities;

namespace Northwind.Application.Rooms.Queries.GetRoomDetails
{
    public class RoomsDetailsModel
    {
        public string Id { get; set; }
        public string Size { get; set; }
        public string ClientName { get; set; }
        public List<DateTime> RentedCalendar { get; set; }
        public string ClientPhone { get; set; }
        public string ClientMail { get; set; }

        public static Expression<Func<Room, RoomsDetailsModel>> Projection
        {
            get
            {
                return room => new RoomsDetailsModel
                {
                    Id = room.Id,
                    Size = room.Size,
                    ClientName = room.ClientName,
                    RentedCalendar = room.RentedCalendar,
                    ClientPhone = room.ClientPhone,
                    ClientMail = room.ClientMail,
                };
            }
        }

        public static RoomsDetailsModel Create(Room room)
        {
            return Projection.Compile().Invoke(room);
        }
    }
}