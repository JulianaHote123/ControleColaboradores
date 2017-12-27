using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using JulianaHote20171222.Models;

namespace JulianaHote20171222.Models
{
    public class Colaborador
    {
        #region Propriedades
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Colaborador")]
        public int ControleCOL { get; set; }

        [ForeignKey("Pessoa")]
        [Display(Name = "Pessoa")]
        [Range(1, 99999)]
        public int ControlePES { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        [ForeignKey("Empresa")]
        [Display(Name = "Empresa")]
        [Range(1, 99999)]
        public int ControleEMP { get; set; }
        public virtual Empresa Empresa { get; set; }

        [Display(Name = "Salário")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Cargo/Função")]
        public string CargoColaborador { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Display(Name = "Data de Demissão")]
        public DateTime? DataDemissao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        #endregion

    }
}