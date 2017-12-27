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
    public class Empresa
    {
        #region Propriedades

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Empresa")]
        public int ControleEMP { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string NomeEMP { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Razão Social")]
        public string RazaoSocialEMP { get; set; }

        [StringLength(18, MinimumLength = 18)]
        [CustomValidationCNPJAttribute(ErrorMessage = "CNPJ inválido")]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        #endregion
    }
}