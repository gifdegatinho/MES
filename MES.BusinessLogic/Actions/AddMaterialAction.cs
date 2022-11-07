using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class AddMaterialAction : ActionBase<AddMaterialRequest, AddMaterialResponse>
    {
        public AddMaterialAction(AddMaterialRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            UnitOfWork.Materials.Add(new Material()
            {
                MaterialId = "Action" + Request.MaterialId,
                Description = Request.Description,
                Color = Request.Color,
            });

            return Task.CompletedTask;
        }
    }
}
