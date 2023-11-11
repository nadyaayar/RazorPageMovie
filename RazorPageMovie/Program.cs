using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPageMovie.Data;
using RazorPageMovie.Models; //agregado pero no funcion?

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPageMovieContext1>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPageMovieContext1") ?? throw new InvalidOperationException("Connection string 'RazorPageMovieContext1' not found.")));
//estaba pero lo eliminamos: builder.Services.AddDbContext<RazorPageMovieContext>(options =>
     //options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPageMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPageMovieContext' not found.")));

var app = builder.Build();

using(var scope = app.Services.CreateScope()) //de esta fila hasta las 2 siguientes se agregan después de programar el SeedData
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); //agregado pero no funcion?
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
