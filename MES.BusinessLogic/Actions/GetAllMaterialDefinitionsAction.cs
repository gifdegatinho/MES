using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System.Linq;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class GetAllMaterialDefinitionsAction : ActionBase<GetAllMaterialDefinitionsRequest, GetAllMaterialDefinitionsResponse>
    {
        public GetAllMaterialDefinitionsAction(Library.Requests.GetAllMaterialDefinitionsRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            var materialDefinitions = UnitOfWork.MaterialDefinitions.GetAll()
                .Where(md => md.MaterialDefinitionId.Contains(Request.SearchText) || md.Description.Contains(Request.SearchText));

            Response.Count = materialDefinitions.Count();

            Response.MaterialDefinitions = materialDefinitions
                .OrderBy(md => md.Description)
                .Skip(Request.PageSize * Request.Page)
                .Take(Request.PageSize)
                .ToList();

            return Task.CompletedTask;
        }
    }
}
