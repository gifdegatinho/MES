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
    public class DeleteEquipmentAction : ActionBase<DeleteEquipmentRequest, DeleteEquipmentResponse>
    {
        public DeleteEquipmentAction(DeleteEquipmentRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            var equipment = UnitOfWork.Equipments.Get(Request.EquipmentId);
            UnitOfWork.Equipments.Delete(equipment);

            return Task.CompletedTask;
        }
    }
}
