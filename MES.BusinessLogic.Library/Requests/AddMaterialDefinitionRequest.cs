namespace MES.BusinessLogic.Library.Requests
{
    public class AddMaterialDefinitionRequest : ActionRequest
    {
        public string MaterialDefinitionId { get; set; }
        public string Description { get; set; }

    }
}
