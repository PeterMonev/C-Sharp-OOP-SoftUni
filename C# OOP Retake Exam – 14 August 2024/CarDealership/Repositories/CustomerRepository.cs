using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        private readonly List<ICustomer> customers;

        public CustomerRepository()
        {
            this.customers = new List<ICustomer>();
        }
        public IReadOnlyCollection<ICustomer> Models => customers;

        public void Add(ICustomer model)
        {
            customers.Add(model);
        }

        public bool Exists(string text)
        {
            return customers.Any(c => c.Name == text);
        }

        public ICustomer Get(string text)
        {
            return customers.FirstOrDefault(c => c.Name == text);
        }

        public bool Remove(string text)
        {
            ICustomer customer = customers.FirstOrDefault(c => c.Name == text);

            if (customer != null)
            {
                customers.Remove(customer);
                return true;
            }

            return false;
        }
    }
}
