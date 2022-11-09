using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Library.Requests
{
    public class GetEquipmentRequest : ActionRequest
    {
        public string EquipmentId { get; set; } 
    }
}
