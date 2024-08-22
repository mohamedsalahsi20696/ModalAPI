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
    internal class BrandRepository : GenaricRepository<Brand>, IBrandRepository
    {

        public BrandRepository(ModalContext context) : base(context)
        {

        }
    }
}
