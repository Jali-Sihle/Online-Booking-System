using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Booking_System_.Startup))]
namespace Online_Booking_System_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
