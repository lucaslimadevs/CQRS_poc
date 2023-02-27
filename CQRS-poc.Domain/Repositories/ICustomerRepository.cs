using CQRS_poc.Domain.Entity;

namespace CQRS_poc.Domain.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<IEnumerable<Customer>> FindCustomers(string name, string address, string phone, string email);
        Task<Customer> FindCustomerById(int id);
    }
}
