using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HelloMvc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            
            app.UseCookieAuthentication(options =>{
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.LoginPath = "/Home/Login";
            });
            
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}


