using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;

namespace MyAbpProject
{
    [DependsOn(typeof(MyAbpProjectCoreModule), typeof(AbpAutoMapperModule))]
    public class MyAbpProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
