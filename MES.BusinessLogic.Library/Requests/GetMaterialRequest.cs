using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Library.Requests
{
    public class GetMaterialRequest : ActionRequest
    {
        public string MaterialId { get; set; }
    }
}
