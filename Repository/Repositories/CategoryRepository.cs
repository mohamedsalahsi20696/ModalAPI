using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.Models;
using Modal.Repository.Data;
using Modal.Repository.Interfaces;

namespace Modal.Repository.Repositories
{
    public class CategoryRepository : GenaricRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(ModalContext context) : base(context)
        {
            
        }
    }
}
