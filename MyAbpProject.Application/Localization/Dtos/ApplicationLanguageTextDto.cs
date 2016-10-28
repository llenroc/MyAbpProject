using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Localization;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;

namespace MyAbpProject.Localization.Dtos
{
    [AutoMap(typeof(ApplicationLanguageText))]
    public class ApplicationLanguageTextDto : EntityDto<long>
    {
        public string LanguageName { get; set; }

        public string Source { get; set; }

        public int? TenantId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
