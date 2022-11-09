using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class GetAllEquipmentsAction : ActionBase<GetAllEquipmentsRequest, GetAllEquipmentsResponse>
    {
        public GetAllEquipmentsAction(GetAllEquipmentsRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            var equipment = UnitOfWork.Equipments.GetAll();

            if (!string.IsNullOrEmpty(Request.SearchString))
            {
                equipment = equipment.Where(e => e.EquipmentId.Contains(Request.SearchString) || e.Description.Contains(Request.SearchString));
            }

            Response.Count = equipment.Count();

            Response.Equipments = equipment
                .OrderBy(e => e.EquipmentId)
                .Skip(Request.PageSize * Request.Page)
                .Take(Request.PageSize)
                .ToList();

            return Task.CompletedTask;
        }
    }
}