using Abp.Domain.Entities;
using MyAbpProject.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Barcodes
{
    public class Barcode : Entity<long>
    {
        public virtual long SerialNumber { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual string Description { get; set; }

        public virtual int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public Barcode() { CreationTime = DateTime.Now; }
    }
}
