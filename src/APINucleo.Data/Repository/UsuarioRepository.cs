using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using APINucleo.Domain.Entities;
using APINucleo.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace APINucleo.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MyContext _context;

        public UsuarioRepository(MyContext context)
        {
            _context = context;
        }
        public async Task<NucleoUsuario> FindByEmail(string email)
        {
            try{
            return await _context.NucleoUsuario.FirstOrDefaultAsync();
            }catch(Exception ex){
                var exe =  ex.ToString();
                return null;
            }
        }

        public async Task<IEnumerable<NucleoUsuario>> GetAll() => await _context.NucleoUsuario.ToListAsync();
    }
}