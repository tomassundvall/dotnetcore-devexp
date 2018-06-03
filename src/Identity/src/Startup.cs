using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TSundvall.DotnetCoreDevExp.Identity
{
    public class Startup
    {
        public ILogger<Startup> _log;
        
        
        public Startup(ILogger<Startup> log)
        {
            _log = log;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }


        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
