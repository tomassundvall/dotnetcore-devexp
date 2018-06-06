using System;
using System.IO;
using System.Reflection;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TSundvall.DotnetCoreDevExp.Identity.Infrastructure;
using TSundvall.DotnetCoreDevExp.Identity.Model;

namespace TSundvall.DotnetCoreDevExp.Identity
{
    public class Startup
    {
        public ILogger<Startup> _log;
        public IConfiguration _config;

        private const string DB_NAME = "Identity";
        private const string DB_SCHEMA_FILENAME = "Identity.schema.DbSchema.sql";
        private string _connectionString;


        public Startup(
            ILogger<Startup> log,
            IConfiguration config)
        {
            _log = log;
            _config = config;

            var connStrBuilder = new SqliteConnectionStringBuilder();
            connStrBuilder.DataSource = $"{DB_NAME}.db";

            _connectionString = connStrBuilder.ConnectionString;

            using (var cn = new SqliteConnection(_connectionString))
            {
                string dbSchema = LoadDbSchema();
                try
                {
                    cn.Execute(dbSchema);
                }
                catch (Exception e)
                {
                    throw new Exception($"Failed to run following schema:\n{dbSchema}\n{e}");
                }
            }
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserStore<AppUser>, UserStore>();
            services.AddTransient<IRoleStore<AppRole>, RoleStore>();
            services.AddIdentity<AppUser, AppRole>().AddDefaultTokenProviders();

            services.AddMvc();
        }


        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
        {
            app.UseMvc();
        }


        private string LoadDbSchema()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string result;
            using (Stream stream = assembly.GetManifestResourceStream(DB_SCHEMA_FILENAME))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }
}
