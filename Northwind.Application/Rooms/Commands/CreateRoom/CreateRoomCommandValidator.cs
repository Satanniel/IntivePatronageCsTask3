using FluentValidation;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.Id).Length(5).NotEmpty();
            RuleFor(x => x.Size).MaximumLength(15).NotEmpty();
            RuleFor(x => x.ClientName).MaximumLength(40).NotEmpty();
            RuleFor(x => x.RentedCalendar).NotEmpty();
            RuleFor(x => x.ClientPhone).MaximumLength(24);
            RuleFor(x => x.ClientMail).MaximumLength(254).NotEmpty();
        }
    }
}
