using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APINucleo.Domain.Entities;
using APINucleo.Domain.Interfaces.Repository;
using APINucleo.Domain.Interfaces.Repository.Services;

namespace APINucleo.Service.Services {
    
    public class UsuarioService : IUsuarioService {
        private readonly IUsuarioRepository _repository;

        public UsuarioService (IUsuarioRepository repository) {
            _repository = repository;
        }

        public Task<NucleoUsuario> Get(string email)
        {
            return _repository.FindByEmail(email);
        }
    }
}
