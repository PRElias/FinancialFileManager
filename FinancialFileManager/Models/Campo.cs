using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialFileManager.Models
{
    public class Campo
    {
        [Key]
        public int CampoId { get; set; }
        public TipodeCampo TipoDoCampo { get; set; }
        [Required]
        public int ArquivoId { get; set; }
        public virtual Arquivo Arquivo {get; set;}
    }
}