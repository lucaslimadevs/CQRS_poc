using CQRS_poc.Commands.Customers.Command;
using CQRS_poc.Domain.Repositories;
using CQRS_poc.Queries.Customers.Query;
using MediatR;

namespace CQRS_poc.Commands.Customers.Handler
{
    public class DisableCustomerCommandHandler : IRequestHandler<DisableCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public DisableCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DisableCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _mediator.Send(new FindCustomerByIdQuery { Id = request.Id });

            if (customer == null) return false;

            customer.Disable();

            _customerRepository.Update(customer);

            return await _unitOfWork.CommitAsync();
        }
    }
}
