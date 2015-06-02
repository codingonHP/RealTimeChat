using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartupAttribute(typeof(SignalRExperiments.Startup))]
namespace SignalRExperiments
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
			HubConfiguration config = new HubConfiguration
			{
				EnableDetailedErrors = true,
				EnableJavaScriptProxies = true
			};
			app.MapSignalR(config);
		}
	}
}
