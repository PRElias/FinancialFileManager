using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace FinancialFileManager.Models
{
    [Authorize]
    public partial class Template
    {
        [Key]
        public int TemplateId { get; set; }
        public string Apelido { get; set; }
        public DateTime DataCriacao { get; set; }
        [MaxLength(128), ForeignKey("ApplicationUser")]
        public virtual string UsuarioId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Tipo de quebra")]
        public TipoQuebra TipoDeQuebra { get; set; }
        public Caracteres Caractere { get; set; }
    }
}