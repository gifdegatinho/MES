using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class ModifyWorkOrderAction : ActionBase<ModifyWorkOrderRequest, ModifyWorkOrderResponse>
    {
        public ModifyWorkOrderAction(ModifyWorkOrderRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            var workOrder = UnitOfWork.WorkOrders.Get(Request.WorkOrderId);
            workOrder.MaterialId = Request.MaterialId;
            workOrder.Quantity = Request.Quantity;

            var oldOperations = UnitOfWork.Operations.GetAll(o => o.WorkOrderId == Request.WorkOrderId);
            UnitOfWork.Operations.DeleteRange(oldOperations);

            foreach (var operation in Request.Operations)
            {
                UnitOfWork.Operations.Add(new Operation()
                {
                    WorkOrderId = Request.WorkOrderId,
                    OperationId = operation.OperationId,
                    EquipmentId = operation.EquipmentId,
                    ScheduledStartDate = operation.ScheduledStartDate,
                    ScheduledEndDate = operation.ScheduledEndDate,
                    ActualStartDate = operation.ActualStartDate,
                    ActualEndDate = operation.ActualEndDate,
                    Duration = operation.Duration,
                    ProducedQuantity = operation.ProducedQuantity,
                    ScrapQuantity = operation.ScrapQuantity
                });
            }

            return Task.CompletedTask;
        }
    }
}

