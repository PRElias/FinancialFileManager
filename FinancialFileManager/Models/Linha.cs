using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialFileManager.Models
{
    public class Linha
    {
        [Key]
        public int LinhaId { get; set; }
        public string Conteudo { get; set; }
        public virtual Arquivo Arquivo { get; set; }
        [Required]
        public int ArquivoId { get; set; }
    }
}