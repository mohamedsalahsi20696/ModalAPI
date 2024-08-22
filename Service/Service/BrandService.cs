using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.DTO;
using Modal.Domain.Models;
using Modal.Domain.Specifications;
using Modal.Domain.SpecificationsModels;
using Modal.Repository.UnitOfWork;
using Modal.Service.Interfaces;
using Modal.Domain.SpecificationsModels;
using Modal.Common.UnitOfWork;

namespace Modal.Service.Service
{
    public class BrandService: IBrandService
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICommonUnitOfWork _commonUnitOfWork;

        public BrandService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper, ICommonUnitOfWork commonUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
            _commonUnitOfWork = commonUnitOfWork;
        }

        public async Task<OkObjectResult> Get(Guid id)
        {
            try
            {
                var specifications = new BrandSpecifications(id);

                Brand productBrand = await _repositoryUnitOfWork.ProductBrand.Value.GetAsync(specifications);
                BrandToReturnDTO brandToReturnDTO = _mapper.Map<BrandToReturnDTO>(productBrand);

                return _commonUnitOfWork.WrappedOkObjectResult.Value.Success(brandToReturnDTO, 1, 1, 1);
            }
            catch (Exception ex)
            {
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Error(ex.Message);
            }
        }

        public async Task<OkObjectResult> GetAll()
        {
            try
            {
                var specifications = new BrandSpecifications();

                var productBrand = await _repositoryUnitOfWork.ProductBrand.Value.GetAllWithoutPaginationAsync(specifications);
                IEnumerable<BrandToReturnDTO> brandToReturnDTO = _mapper.Map<IEnumerable<BrandToReturnDTO>>(productBrand);
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Success(brandToReturnDTO,1, brandToReturnDTO.Count(), brandToReturnDTO.Count());
            }
            catch (Exception ex)
            {
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Error(ex.Message);
            }
        }

        public async Task<OkObjectResult> Search(ProductSpecificationsParamtersDTO productSpecificationsParamtersDTO)
        {
            try
            {
                var specifications = new BrandSpecifications(productSpecificationsParamtersDTO);

                var productBrand = await _repositoryUnitOfWork.ProductBrand.Value.GetAllWithoutPaginationAsync(specifications);
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Success(productBrand, 1, 1, productBrand.Count());
            }
            catch (Exception ex)
            {
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Error(ex.Message);
            }
        }
    }
}
