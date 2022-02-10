using MediatR;
using Microsoft.EntityFrameworkCore;
using PizzeriaMenu.Database;
using PizzeriaMenu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMenu.Application.Handlers.Menu
{
    public class GetAll
    {
        public class Query : IRequest<IEnumerable<Pizza>>
        {

        }
        public class Handler : IRequestHandler<Query, IEnumerable<Pizza>>
        {
            public Handler(Context context)
            {
                Context = context;
            }

            private Context Context { get; }

            public async Task<IEnumerable<Pizza>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await Context.Pizzas
                                    .Include(p => p.Ingredients)
                                    .ToListAsync(cancellationToken);
                
            }
        }

    }
}
