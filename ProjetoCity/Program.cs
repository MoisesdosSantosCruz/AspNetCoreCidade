using ProjetoCity.Libraries.Login;
using ProjetoCity.Repository;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Adicionado para manipular a Sess�o
builder.Services.AddHttpContextAccessor();
//Adicionar a Interface como um servi�o 
// Adicionar servi�os 
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<ProjetoCity.Libraries.Session.Session>();
builder.Services.AddScoped<LoginCliente>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
