using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class AddMaterialDefinitionAction : ActionBase<AddMaterialDefinitionRequest, AddMaterialDefinitionResponse>
    {
        public AddMaterialDefinitionAction(AddMaterialDefinitionRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            Response.MaterialDefinition = new MaterialDefinition()
            {
                MaterialDefinitionId = Request.MaterialDefinitionId,
                Description = Request.Description
            };
            UnitOfWork.MaterialDefinitions.Add(Response.MaterialDefinition);

            return Task.CompletedTask;
        }
    }
}
