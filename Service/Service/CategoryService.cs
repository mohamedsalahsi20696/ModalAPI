using AutoMapper;
using Modal.Common.UnitOfWork;
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

namespace Modal.Service.Service
{
    internal class CategoryService : ICategoryService
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICommonUnitOfWork _commonUnitOfWork;

        public CategoryService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper, ICommonUnitOfWork commonUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
            _commonUnitOfWork = commonUnitOfWork;
        }

        public async Task<OkObjectResult> Get(Guid id)
        {
            try
            {
                var specifications = new CategorySpecifications(id);

                Category productCategory = await _repositoryUnitOfWork.productCategory.Value.GetAsync(specifications);
                CategoryToReturnDTO categoryToReturnDTO = _mapper.Map<CategoryToReturnDTO>(productCategory);

                return _commonUnitOfWork.WrappedOkObjectResult.Value.Success(categoryToReturnDTO, 1, 1, 1);
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
                var specifications = new CategorySpecifications();

                var productCategory = await _repositoryUnitOfWork.productCategory.Value.GetAllWithoutPaginationAsync(specifications);
                IEnumerable<CategoryToReturnDTO> categoryToReturnDTO = _mapper.Map<IEnumerable<CategoryToReturnDTO>>(productCategory);
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Success(categoryToReturnDTO,1, categoryToReturnDTO.Count(), categoryToReturnDTO.Count());
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
                var specifications = new CategorySpecifications(productSpecificationsParamtersDTO);

                var productCategory = await _repositoryUnitOfWork.productCategory.Value.GetAllWithoutPaginationAsync(specifications);
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Success(productCategory, 1, 1, productCategory.Count());
            }
            catch (Exception ex)
            {
                return _commonUnitOfWork.WrappedOkObjectResult.Value.Error(ex.Message);
            }
        }
    }
}
