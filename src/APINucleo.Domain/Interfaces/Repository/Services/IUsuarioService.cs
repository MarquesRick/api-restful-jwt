using System.Threading.Tasks;
using APINucleo.Domain.Entities;

namespace APINucleo.Domain.Interfaces.Repository.Services
{
    public interface IUsuarioService
    {
         Task<NucleoUsuario> Get (string email);
    }
}