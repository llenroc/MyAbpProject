using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace MyAbpProject.Customers
{
    public class Customer : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
    }
}
