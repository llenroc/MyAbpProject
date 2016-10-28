using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AutoMapper;
using MyAbpProject.Barcodes.Dtos;
using MyAbpProject.Customers;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Abp.Linq.Extensions;

namespace MyAbpProject.Barcodes
{
    public class BarcodeAppService : CrudAppService<Barcode, BarcodeDto, long, PagedAndSortedResultRequestDto>, IBarcodeAppService
    {
        private readonly IBarcodeRepository _barcodeRepository;
        private readonly ICustomerRepository _customerRepository;

        public BarcodeAppService(IBarcodeRepository barcodoRepository, ICustomerRepository customerRepository) : base(barcodoRepository)
        {
            _barcodeRepository = barcodoRepository;
            _customerRepository = customerRepository;
        }

        public PagedResultDto<BarcodeDto> GetAll(PagedAndSortedAndFilteredInput input)
        {
            var query = _barcodeRepository.GetAllIncluding(barcode => barcode.Customer);
            var barcodes = query
                .WhereIf(input.SerialNumber.HasValue, barcode => barcode.SerialNumber == input.SerialNumber)
                .WhereIf(string.IsNullOrWhiteSpace(input.CustomerName) == false, barcode => barcode.Customer.Name == input.CustomerName)
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToList();
            var count = _barcodeRepository.Count();
            return new PagedResultDto<BarcodeDto>() { TotalCount = count, Items = Mapper.Map<List<BarcodeDto>>(barcodes)};
        }
    }
}
