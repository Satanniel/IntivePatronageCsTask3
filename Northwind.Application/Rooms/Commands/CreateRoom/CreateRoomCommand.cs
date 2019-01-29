using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using Northwind.Application.Interfaces;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest
    {
        public string Id { get; set; }
        public string Size { get; set; }
        public string ClientName { get; set; }
        public List <DateTime> RentedCalendar { get; set; }
        public string ClientPhone { get; set; }
        public string ClientMail { get; set; }

        public class Handler : IRequestHandler<CreateRoomCommand, Unit>
        {
            private readonly NorthwindDbContext _context;
            private readonly INotificationService _notificationService;
            private readonly IMediator _mediator;

            public Handler(
                NorthwindDbContext context,
                INotificationService notificationService,
                IMediator mediator)
            {
                _context = context;
                _notificationService = notificationService;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
            {
                var entity = new Room
                {
                    Id = request.Id,
                    Size = request.Size,
                    ClientName = request.ClientName,
                    RentedCalendar = request.RentedCalendar,
                    ClientPhone = request.ClientPhone,
                    ClientMail = request.ClientMail
                };

                _context.Rooms.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new RoomCreated { RoomId = entity.Id });

                string mailNotificationSubject = String.Format("New room reservation Id {0}", entity.Id);
                string mailNotificationBody = String.Format("Created the reservation for a {0} room with Id {1}, for {2} who can be contacted via mail - {3} or telephone - {4}", entity.Size, entity.Id, entity.ClientName, entity.ClientPhone, entity.ClientMail);
                new MailNotifications.SendMailNotification(mailNotificationSubject, mailNotificationBody);
                return Unit.Value;
            }
        }
    }
}

