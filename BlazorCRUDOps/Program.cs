using BlazorCRUDOps.Client.Pages;
using BlazorCRUDOps.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlazorCRUDOps.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlazorCRUDOpsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorCRUDOpsContext") ?? throw new InvalidOperationException("Connection string 'BlazorCRUDOpsContext' not found.")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorCRUDOps.Client._Imports).Assembly);

app.Run();
