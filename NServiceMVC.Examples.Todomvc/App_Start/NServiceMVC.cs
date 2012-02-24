using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using NServiceMVC;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NServiceMVC.Examples.Todomvc.App_Start.NServiceMVCActivator), "Start")]

namespace NServiceMVC.Examples.Todomvc.App_Start
{
    public static class NServiceMVCActivator
    {
        public static void Start()
        {
            NServiceMVC.Initialize(config =>
            {
                // Register all controllers in this project (Remember, controllers must extend NServiceMVC.ServiceController!)
				config.RegisterControllerAssembly(Assembly.GetExecutingAssembly());
				
				// Register all models in the Models namespace of this project:
                config.RegisterModelAssembly(Assembly.GetExecutingAssembly(), "NServiceMVC.Examples.Todomvc.Models");
				
				// expose metadata at ~/metadata
                config.Metadata("metadata");
            });
        }
    }
}
