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
    public class DeleteWorkOrderAction : ActionBase<DeleteWorkOrderRequest, DeleteWorkOrderResponse>
    {
        public DeleteWorkOrderAction(DeleteWorkOrderRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            var workOrder = UnitOfWork.WorkOrders.Get(Request.WorkOrderId);
            UnitOfWork.WorkOrders.Delete(workOrder);

            return Task.CompletedTask;
        }
    }
}
