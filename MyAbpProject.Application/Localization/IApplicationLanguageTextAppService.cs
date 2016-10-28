using MyAbpProject.Localization.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyAbpProject.Dtos;

namespace MyAbpProject.Localization
{
    public interface IApplicationLanguageTextAppService : ICrudAppService<ApplicationLanguageTextDto, long, PagedAndSortedResultRequestDto>
    {
        Task UpdateStringAsync(UpdateStringInput input);
        string GetStringOrNull(GetStringOrNullInput input);
        PagedOutput<ApplicationLanguageTextDto> GetAll(PagedAndSortedAndFilteredInput input);

    }
}
