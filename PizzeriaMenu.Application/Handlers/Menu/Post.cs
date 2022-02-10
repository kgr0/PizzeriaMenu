using FluentResults;
using FluentValidation;
using MediatR;
using PizzeriaMenu.Database;
using PizzeriaMenu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMenu.Application.Handlers.Menu
{
    public class Post
    {
        public class Command : IRequest<Result>
        {
            public Command(string name,
            string description,
            List<string> ingredients,
            float price)
            {
                Name = name;
                Description = description;
                Ingredients = ingredients;
                Price = price;
            }

            public string Name { get; set; }

            public string Description { get; set; }

            public List<string> Ingredients { get; set; } = new();

            public float Price { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result>
        {
            public Handler(Context context)
            {
                Context = context;
            }

            private Context Context { get; }

            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                Context.Pizzas.Add(new(request.Name, request.Description, request.Ingredients, request.Price));

                await Context.SaveChangesAsync(cancellationToken);

                return Result.Ok();
            }

        }
    }
}
