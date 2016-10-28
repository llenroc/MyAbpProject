using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyAbpProject.Barcodes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Barcodes
{
    public interface IBarcodeAppService : ICrudAppService<BarcodeDto, long, PagedAndSortedResultRequestDto>
    {
        PagedResultDto<BarcodeDto> GetAll(PagedAndSortedAndFilteredInput input);
    }
}
