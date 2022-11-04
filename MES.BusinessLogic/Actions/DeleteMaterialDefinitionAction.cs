using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class DeleteMaterialDefinitionAction : ActionBase<DeleteMaterialDefinitionRequest, DeleteMaterialDefinitionResponse>
    {
        public DeleteMaterialDefinitionAction(DeleteMaterialDefinitionRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            var materialDefinition = UnitOfWork.MaterialDefinitions.Get(Request.MaterialDefinitionId);
            UnitOfWork.MaterialDefinitions.Delete(materialDefinition);
            return Task.CompletedTask;
        }
    }
}
