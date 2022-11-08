using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Library.Responses;
using MES.Model;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Actions
{
    public class GetAllMaterialsAction : ActionBase<GetAllMaterialsRequest, GetAllMaterialsResponse>
    {
        public GetAllMaterialsAction(GetAllMaterialsRequest request) : base(request)
        {
        }

        public override Task DoExecute()
        {
            var material = UnitOfWork.Materials.GetAll();

            if (!string.IsNullOrEmpty(Request.SearchString))
            {
                material = material.Where(m => m.MaterialId.Contains(Request.SearchString) || m.Description.Contains(Request.SearchString) || m.Color.Contains(Request.SearchString));
            }

            Response.Count = material.Count();

            Response.Materials = material
                .OrderBy(m => m.MaterialId)
                .Skip(Request.PageSize * Request.Page)
                .Take(Request.PageSize)
                .ToList();

            return Task.CompletedTask;
        }
    }
}
