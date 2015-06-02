using SignalRExperiments.Filters;
using System.Web;
using System.Web.Mvc;

namespace SignalRExperiments
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new LoggerFilterAttribute());
		}
	}
}
