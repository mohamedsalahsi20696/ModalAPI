using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.DTO;
using Modal.Domain.Models;
using Modal.Domain.Specifications;

namespace Modal.Domain.SpecificationsModels
{
    public class ProductSpecifications : Specifications<Product>
    {
        // to get all
        public ProductSpecifications()
        {
            Includes.Add(i => i.Brand);
            Includes.Add(i => i.Category);
            OrderByDesc = p => p.CreatedDate;
        }

        // to get
        public ProductSpecifications(Guid id) : base(i => i.ID == id)
        {
            Includes.Add(i => i.Brand);
            Includes.Add(i => i.Category);
        }

        // to search
        public ProductSpecifications(ProductSpecificationsParamtersDTO specParamters)
            : base(
                  p =>
                  (string.IsNullOrEmpty(specParamters.Name) || p.Name.ToLower().Contains(specParamters.Name.ToLower())) &&
                  (string.IsNullOrEmpty(specParamters.BrandId) || p.BrandID == new Guid(specParamters.BrandId)) &&
                  (string.IsNullOrEmpty(specParamters.CategoryId) || p.CategoryID == new Guid(specParamters.CategoryId)) &&
                  (!specParamters.Price.HasValue || p.Price == specParamters.Price))
        {
            #region Includes

            Includes.Add(i => i.Brand);
            Includes.Add(i => i.Category);
            #endregion

            #region Sort

            if (!string.IsNullOrEmpty(specParamters.Sort))
            {
                switch (specParamters.Sort.ToLower())
                {
                    case "priceasc":
                        OrderBy = p => p.Price;
                        break;
                    case "pricedesc":
                        OrderByDesc = p => p.Price;
                        break;
                    case "nameeasc":
                        OrderBy = p => p.Name;
                        break;
                    case "namedesc":
                        OrderByDesc = p => p.Name;
                        break;
                    default:
                        OrderBy = p => p.CreatedDate;
                        break;
                }
            }
            else
            {
                OrderByDesc = p => p.CreatedDate;
            }
            #endregion

            #region Pagination

            specParamters.PageIndex = specParamters.PageIndex < 1 ? 1 : specParamters.PageIndex;
            specParamters.PageSize = specParamters.PageSize > 10 ? 10 : specParamters.PageSize;

            Skip = (specParamters.PageIndex - 1) * specParamters.PageSize;
            Take = specParamters.PageSize;

            #endregion
        }


    }
}
