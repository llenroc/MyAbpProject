using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAbpProject.Localization;
using MyAbpProject.Localization.Dtos;
using System.Globalization;

namespace MyAbpProject.Web.Controllers
{
    public class ApplicationLanguageTextsController : MyAbpProjectControllerBase
    {
        private readonly IApplicationLanguageTextAppService _applicationLanguageTextAppService;

        public ApplicationLanguageTextsController(IApplicationLanguageTextAppService applicationLanguageTextAppService)
        {
            _applicationLanguageTextAppService = applicationLanguageTextAppService;
        }
        public ActionResult Index(int? page)
        {
            var input = new PagedAndSortedAndFilteredInput()
            {
                CurrentPage = page ?? 0,
            };
            input.SkipCount = input.CurrentPage * input.MaxResultCount;

            var applicationLanguageTexts = _applicationLanguageTextAppService.GetAll(input);
            return View(applicationLanguageTexts);
        }
    }
}