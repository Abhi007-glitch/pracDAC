using WebApplication1MVC.Controllers;

namespace WebApplication1MVC
{
    public class Program
    {
        // all the services are included from here -configure services 
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // ***************Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline. ( merging services with HTTP request)
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");  // default error page
            }

            // defining middlewares to be used in the application 

            app.UseStaticFiles(); //  if not mention then wwwroot folder become inaccessible 

            app.UseRouting(); // enable routing 

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
               // Home here Represents HomeController 
               // controller = the controller name (Home is the default controller method can be changed)
               // action = method of controller that will serve the request (default method is given as Index)
               // id = parameter ;
                pattern: "{controller=Employees}/{action=index}/{id:int?}");  // URL pattern - Home/Index/ or Home/Index/1
                       //"{controller=Home}/{action=Index}/{id:int?}/{a}/{b}"-> specifying  type of value id can take 
                       // "{controller=Home}/{action=Index}/{id:int?}/{a}/{b}"- these parameters can be null but must be sep

            /*  app.MapControllerRoute(
                  name: "Emp",
                  pattern: "{Employee}/Details/{id}"
                  );*/

            app.Run();
        }
    }
}
