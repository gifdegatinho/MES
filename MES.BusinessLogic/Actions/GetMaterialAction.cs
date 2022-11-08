using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class GetMaterialAction : ActionBase<GetMaterialRequest, GetMaterialResponse>
    {
        public GetMaterialAction(GetMaterialRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            Response.Material = UnitOfWork.Materials.Get(Request.MaterialId);

            return Task.CompletedTask;
        }
    }
}
