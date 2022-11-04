using System;

namespace MES.BusinessLogic.Library
{
    public class ActionResponse
    {
        public bool Succeeded { get; set; } = true;
        public Exception Exception { get; set; }
    }
}