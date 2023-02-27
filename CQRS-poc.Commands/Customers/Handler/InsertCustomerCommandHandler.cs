using CQRS_poc.Commands.Customers.Command;
using CQRS_poc.Domain.Entity;
using CQRS_poc.Domain.Repositories;
using MediatR;

namespace CQRS_poc.Commands.Customers.Handler
{
    public class InsertCustomerCommandHandler : IRequestHandler<InsertCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InsertCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                Id = request.Id,
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
                Active = request.Active
            };

            await _customerRepository.AddAsync(entity);

            return await _unitOfWork.CommitAsync();
        }
    }
}
