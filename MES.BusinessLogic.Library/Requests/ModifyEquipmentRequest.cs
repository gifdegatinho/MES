using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Library.Requests
{
    public class ModifyEquipmentRequest : ActionRequest
    {
        public string EquipmentId { get; set; }
        public string Description { get; set; }
        public string ParentEquipmentId { get; set; }
    }
}
