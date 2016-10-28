﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace MyAbpProject.Customers
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}
