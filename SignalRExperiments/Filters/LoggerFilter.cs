using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRExperiments.Filters
{
	public class LoggerFilterAttribute : IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			//do nothing
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
		

		}
	}
}