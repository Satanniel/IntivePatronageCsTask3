using FluentValidation;

namespace Northwind.Application.Rooms.Queries.GetRoomDetails
{
    public class GetRoomDetailsQueryValidator : AbstractValidator<GetRoomDetailsQuery>
    {
        public GetRoomDetailsQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty().Length(5);
        }
    }
}