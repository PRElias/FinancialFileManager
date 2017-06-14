using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialFileManager.Models
{
    public class Arquivo
    {
        [Key]
        public int ArquivoId { get; set; }
        public DateTime DataHora { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
    }
}