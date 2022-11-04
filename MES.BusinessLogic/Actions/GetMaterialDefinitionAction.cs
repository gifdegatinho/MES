using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class GetMaterialDefinitionAction : ActionBase<GetMaterialDefinitionRequest, GetAllMaterialDefinitionRequest>
    {
        public GetMaterialDefinitionAction(GetMaterialDefinitionRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            Response.MaterialDefinition = UnitOfWork.MaterialDefinitions.Get(Request.MaterialDefinitionId);
            return Task.CompletedTask;
        }
    }
}
