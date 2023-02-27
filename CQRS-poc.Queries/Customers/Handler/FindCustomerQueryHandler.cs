using CQRS_poc.Domain.Entity;
using CQRS_poc.Domain.Repositories;
using CQRS_poc.Queries.Customers.Query;
using MediatR;

namespace CQRS_poc.Queries.Customers.Handler
{
    public class FindCustomerQueryHandler : IRequestHandler<FindCustomerQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;
        public FindCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> Handle(FindCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.FindCustomers(request.Name, request.Address, request.Phone, request.Email);

            return customers;
        }
    }
}
