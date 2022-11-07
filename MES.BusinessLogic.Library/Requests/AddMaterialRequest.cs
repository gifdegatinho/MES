using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Library.Requests
{
    public class AddMaterialRequest : ActionRequest
    {
        public string MaterialId { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
