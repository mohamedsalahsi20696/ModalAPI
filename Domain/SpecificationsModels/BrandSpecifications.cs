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
    public class BrandSpecifications : Specifications<Brand>
    {
        public BrandSpecifications() : base()
        {
        }

        public BrandSpecifications(Guid id) : base(i => i.ID == id)
        {
        }

        public BrandSpecifications(ProductSpecificationsParamtersDTO specParamters)
         : base(
               p =>
               (string.IsNullOrEmpty(specParamters.Name) || p.Name.ToLower().Contains(specParamters.Name.ToLower())) &&
               (string.IsNullOrEmpty(specParamters.BrandId) || p.ID == new Guid(specParamters.BrandId)))
        {

            #region Includes

            #endregion

            #region Sort

            #endregion

            #region Pagination

            #endregion
        }
    }
}
