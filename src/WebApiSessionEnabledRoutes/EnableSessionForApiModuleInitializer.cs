using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using WebApiSessionEnabledRoutes;

[assembly: System.Web.PreApplicationStartMethod(
  typeof(EnableSessionForApiModuleInitializer),
  nameof(EnableSessionForApiModuleInitializer.Initialize))]
namespace WebApiSessionEnabledRoutes
{
  public static class EnableSessionForApiModuleInitializer
  {
    private static bool _initialized;

    public static void Initialize()
    {
      if (_initialized) return;
      DynamicModuleUtility.RegisterModule(typeof(EnableSessionForApiModule));
      _initialized = true;
    }
  }
}
