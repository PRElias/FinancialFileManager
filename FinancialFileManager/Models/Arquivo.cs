using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
        public int UsuarioId { get; set; }
        public bool TipoDeQuebra { get; set; }
        public Caracteres Caractere { get; set; }
    }
}