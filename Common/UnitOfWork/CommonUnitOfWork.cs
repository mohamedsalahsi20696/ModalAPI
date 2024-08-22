using Modal.Common.Interface;
using Modal.Common.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Repository.Data;
using Modal.Repository.UnitOfWork;

namespace Modal.Common.UnitOfWork
{
    public class CommonUnitOfWork : ICommonUnitOfWork
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly ModalContext _context;

        public Lazy<IWrappedOkObjectResultService> WrappedOkObjectResult { get; set; }

        public CommonUnitOfWork(ModalContext context)
        {
            _context = context;
            _repositoryUnitOfWork = new RepositoryUnitOfWork(context);

            WrappedOkObjectResult = new Lazy<IWrappedOkObjectResultService>(() => new WrappedOkObjectResultService());
        }
    }
}
