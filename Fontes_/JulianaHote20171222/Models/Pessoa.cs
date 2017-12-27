//using JulianaHote20171222.Ultils;
using JulianaHote20171222.Ultils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JulianaHote20171222.Models
{
    public class Pessoa
    {
        #region Propriedades

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Pessoa")]
        public int ControlePES { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string NomePES { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [CustomValidationCPFAttribute(ErrorMessage = "CPF inválido")]
        [StringLength(14, MinimumLength = 14)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "Informe a Data de Cadastro", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        
        [ForeignKey("Empresa")]
        [Display(Name = "Nome da Empresa")]
        public int ControleEMP { get; set; }
        public virtual Empresa Empresa { get; set; }
        
        #endregion
    }
}