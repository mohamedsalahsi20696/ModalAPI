using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Common.Interface
{
    public interface IWrappedOkObjectResultService
    {
        OkObjectResult Success(object objResult, int pageIndex = 1, int pageSize = 1, int totalRecords = 0);
        OkObjectResult SuccessTest(object objResult);
        Task<OkObjectResult> SuccessAsync(object objResult, int totalRecords = 0);
        OkObjectResult Error(string strErrMessage);
    }
}
