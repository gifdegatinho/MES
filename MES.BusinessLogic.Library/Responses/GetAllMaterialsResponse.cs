using MES.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Library.Responses
{
    public class GetAllMaterialsResponse : ActionResponse
    {
        public int Count { get; set; }
        public List<Material> Materials { get; set; }
    }
}
