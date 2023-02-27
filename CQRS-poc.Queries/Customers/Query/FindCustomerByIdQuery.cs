using CQRS_poc.Domain.Entity;
using MediatR;

namespace CQRS_poc.Queries.Customers.Query
{
    public class FindCustomerByIdQuery : IRequest<Customer>
    {        
        public int Id { get; set; }
    }
}
