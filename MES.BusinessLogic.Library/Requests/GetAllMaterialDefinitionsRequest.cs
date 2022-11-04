using System.Collections.Generic;

namespace MES.BusinessLogic.Library.Requests
{
    public class GetAllMaterialDefinitionsRequest : ActionRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
    }
}
