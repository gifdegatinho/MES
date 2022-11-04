namespace MES.BusinessLogic.Library.Requests
{
    public class ModifyMaterialDefinitionRequest : ActionRequest
    {
        public string MaterialDefinitionId { get; set; }
        public string Description { get; set; }

    }
}
