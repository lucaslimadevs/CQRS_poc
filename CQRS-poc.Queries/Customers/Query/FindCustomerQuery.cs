using CQRS_poc.Domain.Entity;
using MediatR;

namespace CQRS_poc.Queries.Customers.Query
{
    public class FindCustomerQuery : IRequest<IEnumerable<Customer>>
    {        
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
