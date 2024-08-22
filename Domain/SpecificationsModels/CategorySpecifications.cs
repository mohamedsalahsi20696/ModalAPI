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
    public class CategorySpecifications : Specifications<Category>
    {
        public CategorySpecifications() : base()
        {
        }

        public CategorySpecifications(Guid id) : base(i => i.ID == id)
        {
        }

        public CategorySpecifications(ProductSpecificationsParamtersDTO specParamters)
          : base(
                p =>
                (string.IsNullOrEmpty(specParamters.Name) || p.Name.ToLower().Contains(specParamters.Name.ToLower())) &&
                (string.IsNullOrEmpty(specParamters.CategoryId) || p.ID == new Guid(specParamters.CategoryId)))
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
