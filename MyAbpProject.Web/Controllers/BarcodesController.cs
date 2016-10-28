using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAbpProject.Barcodes;
using System.Threading.Tasks;
using MyAbpProject.Barcodes.Dtos;
using Abp.Application.Services.Dto;
using Newtonsoft.Json;

namespace MyAbpProject.Web.Controllers
{
    public class BarcodesController : MyAbpProjectControllerBase
    {
        private readonly IBarcodeAppService _barcodeAppService;

        public BarcodesController(IBarcodeAppService barcodeAppService)
        {
            _barcodeAppService = barcodeAppService;
        }
        public ActionResult Index()
        {
            var input = new PagedAndSortedAndFilteredInput() { SerialNumber = 123456L };
            var output = _barcodeAppService.GetAll(input);
            output = _barcodeAppService.GetAll(input as PagedAndSortedResultRequestDto);
            return View(output);
        }

        public ActionResult GridIndex()
        {
            return View();
        }

        public ActionResult TableIndex()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var result = new
            {
                total = 2,
                rows = _barcodeAppService.GetAll(new PagedAndSortedAndFilteredInput()).Items
            };

            return Content(JsonConvert.SerializeObject(result));
        }
    }
}