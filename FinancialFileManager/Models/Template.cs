using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialFileManager.Models
{
    [Authorize]
    public class Template
    {
        [Key]
        public int TemplateId { get; set; }
        public string Apelido { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioCriacaoId { get; set; }
    }
}