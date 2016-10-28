using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Barcodes.Dtos
{
    [AutoMap(typeof(Barcode))]
    public class BarcodeDto : EntityDto<long>
    {
        public long SerialNumber { get; set; }
        public DateTime CreationTime { get; set; }
        public string Description { get; set; }
    }
}
