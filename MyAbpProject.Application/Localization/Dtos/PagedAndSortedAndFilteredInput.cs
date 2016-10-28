using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Localization.Dtos
{
    public class PagedAndSortedAndFilteredInput : PagedAndSortedResultRequestDto, IShouldNormalize, ICustomValidate
    {
        public int CurrentPage { get; set; }
        public void AddValidationErrors(CustomValidationContext context)
        {
        }

        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(Sorting))
            {
                Sorting = "Key ASC";
            }
        }
    }
}
