using System.Collections.Generic;
using System.Threading.Tasks;
using APINucleo.Domain.Entities;

namespace APINucleo.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
         Task<NucleoUsuario> FindByEmail(string email);

         Task<IEnumerable<NucleoUsuario>> GetAll();
    }
}