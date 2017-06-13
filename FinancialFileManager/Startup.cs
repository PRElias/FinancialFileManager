using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinancialFileManager.Startup))]
namespace FinancialFileManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
