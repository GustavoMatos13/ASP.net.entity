using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    [Table("PessoasFisicas")]
    public class Pfisica
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        public string Sexo { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }

        public string Rg { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}