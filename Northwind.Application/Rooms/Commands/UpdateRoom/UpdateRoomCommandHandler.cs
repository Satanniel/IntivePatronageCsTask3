using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
    {
        private readonly NorthwindDbContext _context;

        public UpdateRoomCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms
                .SingleAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            entity.Size = request.Size;
            entity.ClientName = request.ClientName;
            entity.RentedCalendar = request.RentedCalendar;
            entity.ClientPhone = request.ClientPhone;
            entity.ClientMail = request.ClientMail;

            _context.Rooms.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            string mailNotificationSubject = String.Format("Edited the room reservation Id {0}", entity.Id);
            string mailNotificationBody = String.Format("Edited the room reservation for a {0} room with Id {1}, for {2} who can be contacted via mail - {3} or telephone - {4}", entity.Size, entity.Id, entity.ClientName, entity.ClientPhone, entity.ClientMail);
            new MailNotifications.SendMailNotification(mailNotificationSubject, mailNotificationBody);
            return Unit.Value;
        }
    }
}
