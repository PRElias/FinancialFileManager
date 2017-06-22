using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace FinancialFileManager.Models
{
    [Authorize]
    public class Arquivo
    {
        [Key]
        public int ArquivoId { get; set; }
        public DateTime DataHora { get; set; }
        public string Nome { get; set; }
        [MaxLength(128), ForeignKey("ApplicationUser")]
        public virtual string UsuarioId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}