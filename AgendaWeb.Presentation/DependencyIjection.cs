using AgendaWeb.Infra.Data.Interfaces;
using AgendaWeb.Infra.Data.Repositories;

namespace AgendaWeb.Presentation
{
    /// <summary>
    /// Classe para configuração da injeção de dependência do projeto
    /// </summary>
    public class DependencyIjection
    {
        /// <summary>
        /// Método para registrar e configurar as dependências
        /// </summary>
        public static void Register(WebApplicationBuilder builder)
        {
            #region Capturar a connectionstring mapeada no arquivo do appsettings.json

            var connectionstring = builder.Configuration.GetConnectionString("AgendaWebDev");

            #endregion

            #region Configurando a injeção de dependência para o repositório

            builder.Services.AddTransient<IUsuarioRepository>(map => new UsuarioRepository(connectionstring));
            builder.Services.AddTransient<IEventoRepository>(map => new EventoRepository(connectionstring));


            #endregion


        }
    }
}
