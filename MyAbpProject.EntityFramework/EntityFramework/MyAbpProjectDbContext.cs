using System.Data.Common;
using Abp.Zero.EntityFramework;
using MyAbpProject.Authorization.Roles;
using MyAbpProject.MultiTenancy;
using MyAbpProject.Users;
using MyAbpProject.Barcodes;
using System.Data.Entity;
using MyAbpProject.Customers;

namespace MyAbpProject.EntityFramework
{
    public class MyAbpProjectDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        public virtual IDbSet<Barcode> Barcodes { get; set; }
        public virtual IDbSet<Customer> Customers { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public MyAbpProjectDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in MyAbpProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of MyAbpProjectDbContext since ABP automatically handles it.
         */
        public MyAbpProjectDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public MyAbpProjectDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
