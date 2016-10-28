using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyAbpProject.Barcodes.Dtos
{
    public class PagedAndSortedAndFilteredInput : PagedAndSortedResultRequestDto, IShouldNormalize, ICustomValidate
    {
        public long? SerialNumber { get; set; }
        public string CustomerName { get; set; }


        public void AddValidationErrors(CustomValidationContext context)
        {
        }

        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(Sorting))
            {
                Sorting = "SerialNumber DESC";
            }
        }

    }
}
