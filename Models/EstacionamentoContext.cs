using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    public class EstacionamentoContext : DbContext
    {
        public EstacionamentoContext() :base("Estacionamento")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Pfisica> PessoasFisicas { get; set; }
        public DbSet<Pjuridica> PessoasJuridicas { get; set; }
    }
}