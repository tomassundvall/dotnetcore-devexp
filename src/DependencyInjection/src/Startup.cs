namespace TSundvall.DotnetCoreDevExp.DependencyInjection
{
    public class Startup
    {
        public ILogger<Startup> _log;
        public IConfiguration _config;


        public Startup(
            ILogger<Startup> log,
            IConfiguration config)
        {
            _log = log;
            _config = config;
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
