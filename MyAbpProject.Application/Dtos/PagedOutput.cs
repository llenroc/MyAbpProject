using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Dtos
{
    public class PagedOutput<T>: PagedResultDto<T>
    {
        public int PageCount { get; set; }

        public int CurrentPage { get; set; }
    }
}
