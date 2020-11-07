# ASP.NET Core Oct. 2020
Lớp ASP.NET Core khai giảng 17/10/2020


## 1. Enable Razor Runtime
### 1.1 Install Package
```
Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
```
### 1.2 Update ConfigureServices() method
Update the project's Startup.ConfigureServices method to include a call to **AddRazorRuntimeCompilation()**.
```
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }
```

Ref on [MS Document](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation?view=aspnetcore-3.1&tabs=visual-studio)
