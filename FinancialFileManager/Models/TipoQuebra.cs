using System.ComponentModel.DataAnnotations;

namespace FinancialFileManager.Models
{
    public partial class Template
    {
        public enum TipoQuebra
        {
            [Display(Name = "Posição")]
            Posicao = 1,
            Caractere = 2
        }
    }
}