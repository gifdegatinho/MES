using Microsoft.AspNetCore.Mvc;
using MES.BusinessLogic.Core;
using MES.BusinessLogic.Library;

namespace MES.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        private Task<TResponse> ExecuteAction<TAction, TRequest, TResponse>(TRequest request)
            where TAction : ActionBase<TRequest, TResponse>
            where TRequest : ActionRequest
            where TResponse : ActionResponse
        {

            TAction? action = Activator.CreateInstance(typeof(TAction), request) as TAction;
            return action!.Execute();
        }
    }
}