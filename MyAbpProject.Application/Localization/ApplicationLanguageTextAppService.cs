using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Localization;
using MyAbpProject.Localization.Dtos;
using Abp.Runtime.Session;
using MyAbpProject.MultiTenancy;
using System.Globalization;
using Abp.Domain.Repositories;
using System.Linq.Dynamic;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;
using AutoMapper;
using Abp.UI;
using MyAbpProject.Dtos;

namespace MyAbpProject.Localization
{
    public class ApplicationLanguageTextAppService : CrudAppService<ApplicationLanguageText, ApplicationLanguageTextDto, long, PagedAndSortedResultRequestDto>,
        IApplicationLanguageTextAppService
    {
        private readonly IApplicationLanguageTextManager _applicationLanguageTextManager;
        private readonly IRepository<ApplicationLanguageText, long> _applicationLanguageTextRepository;
        public ApplicationLanguageTextAppService(IApplicationLanguageTextManager applicationLanguageTextManager,
            IRepository<ApplicationLanguageText, long> applicationLanguageTextRepository) : base(applicationLanguageTextRepository)
        {
            _applicationLanguageTextManager = applicationLanguageTextManager;
            _applicationLanguageTextRepository = applicationLanguageTextRepository;
        }

        public async Task UpdateStringAsync(UpdateStringInput input)
        {
            await _applicationLanguageTextManager.UpdateStringAsync(input.TenantId, input.SourceName,
                new CultureInfo(input.CultureName), input.Key, input.Value);
        }

        public string GetStringOrNull(GetStringOrNullInput input)
        {
            var text = _applicationLanguageTextManager.GetStringOrNull(input.TenantId, input.SourceName,
                new CultureInfo(input.CultureName), input.Key, input.TryDefaults);
            return text;
        }

        public PagedOutput<ApplicationLanguageTextDto> GetAll(PagedAndSortedAndFilteredInput input)
        {
            var query = _applicationLanguageTextRepository.GetAll();
            var languageTexts = query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToList();
            var count = _applicationLanguageTextRepository.Count();
            return new PagedOutput<ApplicationLanguageTextDto>()
            {
                CurrentPage = input.CurrentPage,
                PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(count) / input.MaxResultCount)),
                TotalCount = count,
                Items = Mapper.Map<List<ApplicationLanguageTextDto>>(languageTexts)
            };
        }

        public override ApplicationLanguageTextDto Create(ApplicationLanguageTextDto input)
        {
            var applicationLanguageTexts = _applicationLanguageTextRepository.GetAll()
                .Where(applicationLanguageText => applicationLanguageText.LanguageName == input.LanguageName
                && applicationLanguageText.Key == input.Key);
            if (applicationLanguageTexts != null && applicationLanguageTexts.Count() != 0)
            {
                throw new UserFriendlyException("异常", "该语言文本已存在！");
            }
            return base.Create(input);
        }
    }
}
