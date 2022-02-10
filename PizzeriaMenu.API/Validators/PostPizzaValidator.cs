using FluentValidation;
using static PizzeriaMenu.Application.Handlers.Menu.Post;

namespace PizzeriaMenu.API.Validators
{
    public class PostPizzaValidator : AbstractValidator<Command>
    {
        public PostPizzaValidator()
        {
            RuleFor(static x => x.Name)
                    .NotEmpty();
            RuleFor(static x => x.Description)
                .MinimumLength(10);
            RuleFor(static x => x.Ingredients)
                .NotEmpty();
            RuleFor(static x => x.Price)
                .ExclusiveBetween(0, 100);
        }
    }
}
