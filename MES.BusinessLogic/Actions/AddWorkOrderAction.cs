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
    public class AddWorkOrderAction : ActionBase<AddWorkOrderRequest, AddWorkOrderResponse>
    {
        public AddWorkOrderAction(AddWorkOrderRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            UnitOfWork.WorkOrders.Add(new WorkOrder()
            {
                WorkOrderId = Request.WorkOrderId,
                MaterialId = Request.MaterialId,
                Quantity = Request.Quantity
            });

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