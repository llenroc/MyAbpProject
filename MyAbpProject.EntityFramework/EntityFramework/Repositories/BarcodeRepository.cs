using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using MyAbpProject.Barcodes;
using System.Data.Entity;

namespace MyAbpProject.EntityFramework.Repositories
{
    public class BarcodeRepository : MyAbpProjectRepositoryBase<Barcode, long>, IBarcodeRepository
    {
        public BarcodeRepository(IDbContextProvider<MyAbpProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
