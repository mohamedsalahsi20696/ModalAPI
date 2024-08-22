using Modal.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Common.UnitOfWork
{
    public interface ICommonUnitOfWork
    {
        Lazy<IWrappedOkObjectResultService> WrappedOkObjectResult { get; set; }
    }
}
