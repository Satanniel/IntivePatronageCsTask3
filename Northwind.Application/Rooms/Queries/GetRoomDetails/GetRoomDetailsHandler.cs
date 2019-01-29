using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Queries.GetRoomDetails
{
    public class GetRoomDetailsQueryHandler : IRequestHandler<GetRoomDetailsQuery, RoomsDetailsModel>
    {
        private readonly NorthwindDbContext _context;

        public GetRoomDetailsQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<RoomsDetailsModel> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            return new RoomsDetailsModel
            {
                Id = entity.Id,
                Size = entity.Size,
                ClientName = entity.ClientName,
                RentedCalendar = entity.RentedCalendar,
                ClientPhone = entity.ClientPhone,
                ClientMail = entity.ClientMail,
            };
        }
    }
}
