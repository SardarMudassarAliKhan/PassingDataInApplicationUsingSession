In ASP.NET Core MVC, you can pass data between different parts of your application using sessions. Sessions allow you to store user-specific data that persists across multiple requests.

Here's how you can use sessions to pass data in an ASP.NET Core MVC application:

1. **Configure Session in Startup.cs:**
   In the `Startup.cs` file, configure session services in the `ConfigureServices` method.

   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.AddSession(options =>
       {
           options.Cookie.IsEssential = true; // make the session cookie essential
       });

       services.AddMvc(); // Add other services
   }
   ```

2. **Enable Session in Middleware:**
   In the `Configure` method of `Startup.cs`, enable session usage by adding `UseSession()` middleware.

   ```csharp
   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
   {
       app.UseSession(); // Enable session before MVC
       app.UseMvc(routes =>
       {
           routes.MapRoute(
               name: "default",
               template: "{controller=Home}/{action=Index}/{id?}");
       });
   }
   ```

3. **Setting and Getting Data in Controllers:**
   In your controller actions, you can set and retrieve data from the session.

   ```csharp
   public IActionResult Index()
   {
       HttpContext.Session.SetString("Username", "JohnDoe");
       return View();
   }

   public IActionResult About()
   {
       string username = HttpContext.Session.GetString("Username");
       ViewData["Username"] = username;
       return View();
   }
   ```

4. **Accessing Session in Views:**
   You can also access session data directly in your views.

   ```html
   <h1>Welcome, @HttpContext.Session.GetString("Username")</h1>
   ```

Remember, sessions are user-specific and are maintained using cookies or other mechanisms, so they should be used carefully for sensitive data and scaled appropriately to avoid performance issues. Also, ensure proper handling of session expiration and security considerations.
