using AgendaWeb.Presentation;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Configurar o projeto para o padr�o MVC.
builder.Services.AddControllersWithViews();

//Habilitar o uso de sess�o no projeto(Sessions)
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Configura��o de Inje��o de Depend�ncia do projeto
DependencyIjection.Register(builder);


//habilitando o projeto para usar permiss�o de acesso (Ticket) atrav�s de arquivo cookie
builder.Services.Configure<CookiePolicyOptions>
    (options => { options.MinimumSameSitePolicy = SameSiteMode.None;});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
    

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

//Habilitando o uso da session
app.UseSession();


//Grava��o, Autentica��o e Autoriza��o
app.UseCookiePolicy();  
app.UseAuthentication(); 
app.UseAuthorization();


//Definir qual � a pagina inicial do projeto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{Action=Login}");

app.Run();
