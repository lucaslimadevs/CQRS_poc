using MediatR;

namespace CQRS_poc.Commands.Customers.Command
{
    public class DisableCustomerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
