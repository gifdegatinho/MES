using MES.Model;
using System.Collections.Generic;

namespace MES.BusinessLogic.Library.Responses
{
    public class GetAllMaterialDefinitionsResponse : ActionResponse
    {
        public List<MaterialDefinition> MaterialDefinitions { get; set; }
        public int Count { get; set; }
    }
}
