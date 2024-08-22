using AutoMapper;
using Modal.Common.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.DTO;
using Modal.Domain.Models;
using Modal.Domain.Specifications;
using Modal.Domain.SpecificationsModels;
using Modal.Repository.UnitOfWork;
using Modal.Service.Interfaces;

namespace Modal.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICommonUnitOfWork _commonUnitOfWork;

        public ProductService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper, ICommonUnitOfWork commonUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
            _commonUnitOfWork = commonUnitOfWork;
        }

        public async Task<OkObjectResult> Get(Guid id)
        {
            try
            {
                var specifications = new ProductSpecifications(id);

                Product product = await _repositoryUnitOfWork.Product.Value.GetAsync(specifications);
                ProductToReturnDTO productToReturnDTO = _mapper.Map<ProductToReturnDTO>(product);

                return _commonUnitOfWork.WrappedOkObjectResult.Value.SuccessTest(productToReturnDTO);
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
                var specifications = new ProductSpecifications();

                var product = await _repositoryUnitOfWork.Product.Value.GetAllWithoutPaginationAsync(specifications);
                IEnumerable<ProductToReturnDTO> productToReturnDTO = _mapper.Map<IEnumerable<ProductToReturnDTO>>(product);
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Success(productToReturnDTO, 1, productToReturnDTO.Count(), productToReturnDTO.Count());
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
                var specifications = new ProductSpecifications(productSpecificationsParamtersDTO);

                var productCount = await _repositoryUnitOfWork.Product.Value.GetCountAsync(specifications);
                var product = await _repositoryUnitOfWork.Product.Value.GetAllAsync(specifications);
                IEnumerable<ProductToReturnDTO> productToReturnDTO = _mapper.Map<IEnumerable<ProductToReturnDTO>>(product);
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Success(productToReturnDTO, productSpecificationsParamtersDTO.PageIndex, productSpecificationsParamtersDTO.PageSize, productCount);
            }
            catch (Exception ex)
            {
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Error(ex.Message);
            }
        }

        public async Task<OkObjectResult> Insert(ProductInsertDTO productDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDTO);
                await _repositoryUnitOfWork.Product.Value.AddAsync(product);

                await _repositoryUnitOfWork.CompleteAsync();

                return _commonUnitOfWork.WrappedOkObjectResult.Value.Success(product, 1, 1, 1);
            }
            catch (Exception ex)
            {
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Error(ex.Message);
            }
        }


    }
}
