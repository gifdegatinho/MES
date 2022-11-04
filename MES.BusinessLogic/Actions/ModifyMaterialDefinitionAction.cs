using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class ModifyMaterialDefinitionAction : ActionBase<ModifyMaterialDefinitionRequest, ModifyMaterialDefinitionResponse>
    {
        public ModifyMaterialDefinitionAction(ModifyMaterialDefinitionRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            Response.MaterialDefinition = UnitOfWork.MaterialDefinitions.Get(Request.MaterialDefinitionId);
            Response.MaterialDefinition.Description = Request.Description;
            return Task.CompletedTask;
        }
    }
}
