using System;
using System.ComponentModel.DataAnnotations;

namespace APINucleo.Domain.Entities
{
    public class NucleoUsuario
    {
        public decimal IdUsuario { get; set; }
        public string Version { get; set; }
        public bool ContaBloqueada { get; set; }
        public bool ContaExpirada { get; set; }
        public string Cpf { get; set; }
        public decimal? Criador { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string Email { get; set; }
        public bool? ReceberEmail { get; set; }
        public string Senha { get; set; }
        public bool? SenhaExpirada { get; set; }
        public bool? SenhaResetada { get; set; }
        public string Sexo { get; set; }
        public bool Status { get; set; }
        public string Usuario { get; set; }
        public decimal? IdUsuarioPep { get; set; }
        public bool? PrimeiroAcesso { get; set; }
        public long? CidadeId { get; set; }
        public string NomeUsuario { get; set; }
        public string Telefone { get; set; }
        public decimal? TipoId { get; set; }
    }
}