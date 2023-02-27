using CQRS_poc.Domain.Entity;
using CQRS_poc.Domain.Repositories;
using CQRS_poc.Queries.Customers.Query;
using MediatR;

namespace CQRS_poc.Queries.Customers.Handler
{
    public class FindCustomerByIdQueryHandler : IRequestHandler<FindCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public FindCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(FindCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindCustomerById(request.Id);

            return customer;
        }
    }
}
