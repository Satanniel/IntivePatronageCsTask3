using AutoMapper;
using Northwind.Application.Interfaces.Mapping;
using Northwind.Domain.Entities;

namespace Northwind.Application.Rooms.Queries.GetRooms
{
    public class RoomLookupModel : IHaveCustomMapping
    {
        public string Id { get; set; }
        public string ClientName { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Room, RoomLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.ClientName, opt => opt.MapFrom(c => c.ClientName));
        }
    }
}
