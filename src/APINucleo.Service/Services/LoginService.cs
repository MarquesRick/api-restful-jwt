using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Security;
using APINucleo.Domain.Entities;
using APINucleo.Domain.Interfaces.Repository;
using APINucleo.Domain.Interfaces.Repository.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APINucleo.Service.Services
{

    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _repository;

        private SigningConfigurations _signingConfigurations { get; }

        private readonly IConfiguration _configuration;
        private readonly TokenConfigurations _tokenConfigurations;

        public LoginService(IUsuarioRepository repository,
                        IConfiguration configuration,
                        SigningConfigurations signingConfigurations,
                        TokenConfigurations tokenConfigurations)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
            _tokenConfigurations = tokenConfigurations;
        }

        public async Task<object> FindByLogin(string email, string senha)
        {
            var baseUser = new NucleoUsuario();
            if (!string.IsNullOrWhiteSpace(email))
            {
                baseUser = await _repository.FindByEmail(email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    var userClaims = new List<Claim>();
                    var roles = new Dictionary<int, string>();
                    roles.Add(1,"teste");
                    roles.Add(2,"teste2");
                    userClaims.AddRange(roles.Select(x => new Claim(
                        ClaimsIdentity.DefaultRoleClaimType, x.Value.ToString()
                    )));
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jti O id do token
                            new Claim(JwtRegisteredClaimNames.UniqueName, baseUser.Email),
                        }
                    );
                    identity.AddClaims(userClaims);
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);  //60 segundos = 1 minuto

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, baseUser);
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, NucleoUsuario user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                name = user.NomeUsuario,
                message = "Usuário Logado com sucesso"
            };
        }

        public async Task<IEnumerable<NucleoUsuario>> GetAll() => await _repository.GetAll();
    }
}
