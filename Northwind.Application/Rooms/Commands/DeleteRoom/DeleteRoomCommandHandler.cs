using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly NorthwindDbContext _context;

        public DeleteRoomCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            _context.Rooms.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            string mailNotificationSubject = String.Format("Removed the room reservation Id {0}", request.Id);
            string mailNotificationBody = String.Format("Removed the room reservation Id {0}", request.Id);
            new MailNotifications.SendMailNotification(mailNotificationSubject, mailNotificationBody);
            return Unit.Value;
        }
    }
}