using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Library.Requests
{
    public class DeleteWorkOrderRequest : ActionRequest
    {
        public string WorkOrderId { get; set; }
    }
}
