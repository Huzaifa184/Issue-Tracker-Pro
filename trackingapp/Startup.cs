using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using trackingapp.Data;

namespace ISSUE_TRACKING
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IssueDbContext>(options =>
                options.UseSqlite(_configuration.GetConnectionString("IssueDatabase")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // configure middleware pipeline here
        }
    }
}

