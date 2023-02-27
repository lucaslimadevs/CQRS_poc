using CQRS_poc.Domain.Entity;
using CQRS_poc.Domain.Repositories;
using CQRS_poc.Infra.Sqlite.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRS_poc.Infra.Sqlite.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {        
        public CustomerRepository(AppDbContext context) : base(context)
        {            
        }

        public async Task<Customer> FindCustomerById(int id)
        {
            var customer = await DbSet
                .FirstOrDefaultAsync(e => e.Id == id && e.Active);

            return customer ?? new Customer();
        }

        public async Task<IEnumerable<Customer>> FindCustomers(string name, string address, string phone, string email)
        {
            var query = DbSet
                .Where(e => e.Active)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name.ToUpper().Contains(name.ToUpper()));
            }

            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(x => x.Address.ToUpper().Contains(address.ToUpper()));
            }

            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(x => x.Phone.ToUpper().Contains(phone.ToUpper()));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.Email.ToUpper().Contains(email.ToUpper()));
            }

            return await query.ToListAsync();
        }
    }
}
