using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.Tests
{
    public class FakeContainerManager
    {
        private IServiceCollection _services;

        public FakeContainerManager()
        {
            _services = new ServiceCollection();

            SetupCommonServices();
        }

        public IServiceCollection Services { get { return _services; } }
        private void SetupCommonServices()
        {
            //setup logs, https, etc.
        }
        public IServiceProvider GetServiceProvider()
        {
            return _services.BuildServiceProvider();
        }
        

    }
}
