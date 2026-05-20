using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectFlow.Models
{
    public class Configuracao
    {
        [Key]
        public int IdConfig { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; } 

        public string SistemaOrigem { get; set; } = string.Empty;

        public string SistemaDestino { get; set; } = string.Empty;

        public string VolumeDados { get; set; } = string.Empty;

        public bool SuporteLibras { get; set; }

        public bool NotificacoesEmail { get; set; }

        public virtual ICollection<LogTransacao> Logs { get; set; } = new List<LogTransacao>();
    }
}
