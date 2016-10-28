using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Localization.Dtos
{
    public class GetStringOrNullInput : IShouldNormalize
    {
        public int? TenantId { get; set; }
        public string SourceName { get; set; }
        public string CultureName { get; set; }
        public string Key { get; set; }
        public bool TryDefaults { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(SourceName))
            {
                SourceName = MyAbpProjectConsts.LocalizationSourceName;
            }
        }
    }
}
