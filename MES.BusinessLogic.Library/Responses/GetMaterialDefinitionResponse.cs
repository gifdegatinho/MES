using MES.Model;

namespace MES.BusinessLogic.Library.Responses
{
    public class GetAllMaterialDefinitionRequest : ActionResponse
    {
        public MaterialDefinition MaterialDefinition { get; set; }
    }
}
