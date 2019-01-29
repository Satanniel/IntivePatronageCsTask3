using MediatR;

namespace Northwind.Application.Rooms.Queries.GetRoomDetails
{ 
    public class GetRoomDetailsQuery : IRequest<RoomsDetailsModel>
    {
        public string Id { get; set; }
    }
}
