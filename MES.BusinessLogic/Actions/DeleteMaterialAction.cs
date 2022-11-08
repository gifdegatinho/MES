using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class DeleteMaterialAction : ActionBase<DeleteMaterialRequest, DeleteMaterialResponse>
    {
        public DeleteMaterialAction(DeleteMaterialRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            var material = UnitOfWork.Materials.Get(Request.MaterialId);
            UnitOfWork.Materials.Delete(material);

            return Task.CompletedTask;
        }
    }
}
