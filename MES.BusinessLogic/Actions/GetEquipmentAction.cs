using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class GetEquipmentAction : ActionBase<GetEquipmentRequest, GetEquipmentResponse>
    {
        public GetEquipmentAction(GetEquipmentRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            Response.Equipment = UnitOfWork.Equipments.Get(Request.EquipmentId);

            return Task.CompletedTask;
        }
    }
}
