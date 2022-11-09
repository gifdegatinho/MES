﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Library.Requests
{
    public class GetAllEquipmentsRequest : ActionRequest
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public string SearchString { get; set; }
    }
}
