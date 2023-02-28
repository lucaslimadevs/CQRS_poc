using CQRS_poc.Commands.Customers.Command;
using CQRS_poc.Queries.Customers.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_poc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Find")]
        public async Task<IActionResult> GetCustomers([FromBody] FindCustomerQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomersById([FromRoute] int id)
        {
            var result = await _mediator.Send(new FindCustomerByIdQuery { Id = id });

            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertCustomer([FromBody] InsertCustomerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("Disable/{id}")]
        public async Task<IActionResult> DisableCustomer([FromRoute] int id)
        {
            var result = await _mediator.Send(new DisableCustomerCommand { Id = id });

            return Ok(result);
        }
    }
}