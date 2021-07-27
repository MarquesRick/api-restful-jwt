using APINucleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APINucleo.Data.Mapping {
    public class NucleoUsuarioMap : IEntityTypeConfiguration<NucleoUsuario> {
        public void Configure (EntityTypeBuilder<NucleoUsuario> entity) {

                entity.HasKey(e => e.IdUsuario)
                    .HasName("SYS_C0093177");

                entity.ToTable("TB_NUCLEO_USUARIO");

                entity.Property(e => e.IdUsuario)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID_USUARIO");

                entity.Property(e => e.CidadeId)
                    .HasColumnName("CIDADE_ID");

                entity.Property(e => e.ContaBloqueada)
                    .HasColumnName("CONTA_BLOQUEADA");

                entity.Property(e => e.ContaExpirada)
                    .HasColumnName("CONTA_EXPIRADA");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Criador)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CRIADOR");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("DATE")
                    .HasColumnName("DATA_CRIACAO")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.IdUsuarioPep)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID_USUARIO_PEP")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NomeUsuario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOME_USUARIO");

                entity.Property(e => e.PrimeiroAcesso)
                    .HasColumnName("PRIMEIRO_ACESSO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReceberEmail)
                    .HasColumnName("RECEBER_EMAIL")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SENHA");

                entity.Property(e => e.SenhaExpirada)
                    .HasColumnName("SENHA_EXPIRADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SenhaResetada)
                    .HasColumnName("SENHA_RESETADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONE");

                entity.Property(e => e.TipoId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TIPO_ID");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VERSION");
        }
    }
}
