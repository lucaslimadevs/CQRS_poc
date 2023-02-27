namespace CQRS_poc.Domain.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Active { get; set; }

        public void Disable()
        {
            Active = false;
        }
    }
}
