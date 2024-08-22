using Modal.Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modal.Domain.Models;
using Modal.Domain.ReturnJsonModel;

namespace Modal.Common.Service
{
    public class WrappedOkObjectResultService : IWrappedOkObjectResultService
    {
        public OkObjectResult Success(object objResult, int pageIndex = 1, int pageSize = 1, int totalRecords = 0)
        {
            return new OkObjectResult(new SuccessJsonModel(200, objResult, pageIndex, pageSize, totalRecords) { });
        }

        public OkObjectResult SuccessTest(object objResult)
        {
            return new OkObjectResult(new JsonModel(200, objResult) { });
        }

        public async Task<OkObjectResult> SuccessAsync(object objResult, int totalRecords = 0)
        {
            return new OkObjectResult(new SuccessJsonModel(200, objResult, totalRecords) { });
        }

        public OkObjectResult Error(string strErrMessage)
        {
            return new OkObjectResult(new ErrorJsonModel(400, null, strErrMessage) { });
        }
    }
}
