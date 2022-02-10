using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzeriaMenu.API.Validators;
using PizzeriaMenu.Domain;
using static PizzeriaMenu.Application.Handlers.Menu.GetAll;
using static PizzeriaMenu.Application.Handlers.Menu.Post;

namespace PizzeriaMenu.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public MenuController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Dto.GetPizza>> GetAll()
        {
            var pizzas = await _mediator.Send(new Query());
            return _mapper.Map<IEnumerable<Dto.GetPizza>>(pizzas);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody]
            Command pizza,
            CancellationToken cancellationToken)
        {
            var validator = new PostPizzaValidator();
            var validationResult = await validator.ValidateAsync(pizza);
            if (!validationResult.IsValid)
            {
                return StatusCode(400, validationResult.Errors.Select(e => e.ErrorMessage));
            }  
            
            await _mediator.Send(pizza, cancellationToken);

            return Ok();
        }
    }
}
