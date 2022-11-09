using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class ModifyEquipmentAction : ActionBase<ModifyEquipmentRequest, ModifyEquipmentResponse>
    {
        public ModifyEquipmentAction(ModifyEquipmentRequest request) : base(request)
        {

        }



        public override Task DoExecute()
        {
            var equipment = UnitOfWork.Equipments.Get(Request.EquipmentId);
            equipment.Description = Request.Description;
            equipment.ParentEquipmentId = Request.ParentEquipmentId;

            return Task.CompletedTask;
        }
    }
}
