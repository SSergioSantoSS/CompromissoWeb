using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaWeb.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface do Repositório Genérico
    /// </summary>
    /// <typeparam name="TEntity">Tipo Genérico para as Classes de Entidade</typeparam>  
    public interface IBaseRepository<TEntity> 
        where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> GetAll();
        TEntity Get(Guid id);
    }
}
