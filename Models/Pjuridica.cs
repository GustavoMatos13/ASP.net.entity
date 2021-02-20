using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    [Table("PessoasJuridicas")]
    public class Pjuridica
    {
        public int Id { get; set; }

        [Required]
        public string Razaosocial { get; set; }

        [Required]
        public string Cnpj { get; set; }

        public string Nomefantasia { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
