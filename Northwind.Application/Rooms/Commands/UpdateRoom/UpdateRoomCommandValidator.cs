using FluentValidation;
using FluentValidation.Validators;

namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
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