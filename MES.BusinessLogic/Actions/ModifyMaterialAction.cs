using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class ModifyMaterialAction : ActionBase<ModifyMaterialRequest, ModifyMaterialResponse>
    {
        public ModifyMaterialAction(ModifyMaterialRequest request) : base(request)
        {

        }
        
    

public override Task DoExecute()
    {
        var material = UnitOfWork.Materials.Get(Request.MaterialId);
        material.Description = Request.Description;
        material.Color = Request.Color;

        return Task.CompletedTask;
    }
  }
}
