using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VapeShop_BLL.Contracts;

namespace VapeShop_BLL
{
    public static class VapeShopBLL_ModuleHead
    {

        internal struct InterfaceToImplementation
        {
            public Type Implementation;
            public Type Interface;
        }
        public static void RegisterModule(IServiceCollection services)
        {
            var currentAssembly = Assembly.GetAssembly(typeof(VapeShopBLL_ModuleHead));

            var allTypesInThisAssembly = currentAssembly.GetTypes();

            var serviceTypes = allTypesInThisAssembly
                .Where(type =>
                    type.IsAssignableTo(typeof(IService))
                    && !type.IsInterface
                );

            var interfaceToImplementationMap = serviceTypes.Select(serviceType =>
            {
                var implementation = serviceType;
                var @interface = serviceType.GetInterfaces()
                    .First(serviceInterface => serviceInterface != typeof(IService));

                return new InterfaceToImplementation
                {
                    Interface = @interface,
                    Implementation = implementation,
                };
            });


            foreach (var serviceToInterface in interfaceToImplementationMap)
            {
                services.AddTransient(serviceToInterface.Interface, serviceToInterface.Implementation);
            }
        }
    }
}
