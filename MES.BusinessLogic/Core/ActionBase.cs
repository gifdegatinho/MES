using AtomosHyla.Core.Library;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MES.BusinessLogic.Library;
using MES.Persistence;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MES.BusinessLogic.Core
{
    public abstract class ActionBase<TActionRequest, TActionResponse>
        where TActionRequest : ActionRequest
        where TActionResponse : ActionResponse
    {
        protected UnitOfWork UnitOfWork { get; set; }
        public TActionResponse Response { get; private set; }
        public TActionRequest Request { get; }

        public ActionBase(TActionRequest request)
        {
            Request = request;
        }

        public async Task<TActionResponse> Execute()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Logger.LogInformation($"Executing {this.GetType().Name} action.");
            try
            {
                Response = (TActionResponse)Activator.CreateInstance(typeof(TActionResponse));
                UnitOfWork = new UnitOfWork(new DataContextFactory().CreateDbContext());
                await DoExecute();

                UnitOfWork.Save();
            }
            catch (Exception ex)
            {
                var exception = ex;
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }
                Logger.LogError(exception.Message);
                Logger.LogError(exception.Source);
                Logger.LogError(exception.StackTrace);
                Response.Succeeded = false;
                Response.Exception = exception;
            }
            stopwatch.Stop();
            Logger.LogInformation($"Execution time of {this.GetType().Name} action {stopwatch.Elapsed.TotalMilliseconds:F2} ms.");

            return Response;
        }

        public abstract Task DoExecute();
        protected ILogger _Logger;
        public ILogger Logger
        {
            get
            {
                if (_Logger == null)
                {
                    _Logger = ServiceProviderFactory.ServiceProvider.GetService<ILoggerFactory>().CreateLogger(GetType());
                }
                return _Logger;
            }
        }

		protected IConfiguration _Configuration;
		public IConfiguration Configuration
		{
			get
			{
				if (_Configuration == null)
				{
					_Configuration = ServiceProviderFactory.ServiceProvider.GetService<IConfiguration>();
                }
				return _Configuration;
			}
		}
    }
}
