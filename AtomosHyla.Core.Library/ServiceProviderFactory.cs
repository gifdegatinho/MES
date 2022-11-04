using Microsoft.Extensions.DependencyInjection;
using System;

namespace AtomosHyla.Core.Library
{
    public static class ServiceProviderFactory
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IServiceCollection _ServiceCollection;
        public static IServiceCollection ServiceCollection
        {
            get
            {
                if (_ServiceCollection == null)
                {
                    _ServiceCollection = new ServiceCollection();
                }
                return _ServiceCollection;
            }
            set
            {
                _ServiceCollection = value;
            }
        }

        public static IServiceProvider BuildServiceProvider()
        {
            ServiceProvider = ServiceCollection.BuildServiceProvider();
            return ServiceProvider;
        }
    }
}
