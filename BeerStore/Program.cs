var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// structuur opgeven -> er zijn verschillende routes mogelijk
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
            name: "MyAreaProducts",
            areaName: "Admin",
            pattern: "Admin/{controller=Beer}/{action=Index}/{id?}");


    endpoints.MapAreaControllerRoute(
          name: "MyAreaProducts",
          areaName: "Europe",
          pattern: "Europe/{controller=Europe}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});


app.Run();