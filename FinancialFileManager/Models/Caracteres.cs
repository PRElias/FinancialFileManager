using System.ComponentModel.DataAnnotations;

namespace FinancialFileManager.Models
{
    public enum Caracteres
    {
        [Display(Name = "Ponto e vírgula")]
        PontoVirgula = 1,
        Virgula = 2,
        Pipe = 3
    }
}