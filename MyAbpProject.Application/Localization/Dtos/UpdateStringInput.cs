using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Localization.Dtos
{
    public class UpdateStringInput : IShouldNormalize
    {
        public int? TenantId { get; set; }
        public string SourceName { get; set; }
        public string CultureName { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(SourceName))
            {
                SourceName = MyAbpProjectConsts.LocalizationSourceName;
            }

            if (string.IsNullOrWhiteSpace(Value))
            {
                Value = Key;
            }
        }
    }
}
