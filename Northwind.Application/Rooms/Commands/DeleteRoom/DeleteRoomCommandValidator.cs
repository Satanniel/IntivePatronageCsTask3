using FluentValidation;

namespace Northwind.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteRoomCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().Length(5);
        }
    }
}
