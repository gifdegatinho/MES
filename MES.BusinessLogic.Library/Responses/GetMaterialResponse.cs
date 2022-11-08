using MES.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Library.Responses
{
    public class GetMaterialResponse : ActionResponse
    {
        public Material Material { get; set; }
    }
}
