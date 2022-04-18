using AgendaWeb.Presentation;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Configurar o projeto para o padrão MVC.
builder.Services.AddControllersWithViews();

//Habilitar o uso de sessão no projeto(Sessions)
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Configuração de Injeção de Dependência do projeto
DependencyIjection.Register(builder);


//habilitando o projeto para usar permissão de acesso (Ticket) através de arquivo cookie
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


//Gravação, Autenticação e Autorização
app.UseCookiePolicy();  
app.UseAuthentication(); 
app.UseAuthorization();


//Definir qual é a pagina inicial do projeto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{Action=Login}");

app.Run();
