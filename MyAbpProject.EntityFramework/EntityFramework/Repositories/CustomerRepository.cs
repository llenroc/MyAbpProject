using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using MyAbpProject.Customers;

namespace MyAbpProject.EntityFramework.Repositories
{
    public class CustomerRepository : MyAbpProjectRepositoryBase<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(IDbContextProvider<MyAbpProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
