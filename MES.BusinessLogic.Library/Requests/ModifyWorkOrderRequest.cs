using MES.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Library.Requests
{
    public class ModifyWorkOrderRequest : ActionRequest
    {
        public string WorkOrderId { get; set; }
        public string MaterialId { get; set; }
        public double Quantity { get; set; }
        public List<Operation> Operations { get; set; } = new List<Operation>();
    }
}
