using System.Collections.Generic;
using System.Threading.Tasks;
using APINucleo.Domain.Entities;

namespace APINucleo.Domain.Interfaces.Repository.Services
{
    public interface ILoginService
    {
         Task<object> FindByLogin (string email, string senha);

        Task<IEnumerable<NucleoUsuario>> GetAll();
    }
}