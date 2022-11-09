using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class AddEquipmentAction : ActionBase<AddEquipmentRequest, AddEquipmentResponse>
    {
        public AddEquipmentAction(AddEquipmentRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            UnitOfWork.Equipments.Add(new Equipment()
            {
                EquipmentId = Request.EquipmentId,
                Description = Request.Description,
                ParentEquipmentId = Request.ParentEquipmentId
            });

            return Task.CompletedTask;
        }
    }
}

