using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectFlow.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]

        [Column("ID")]
        public int IdCliente { get; set; }


        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter 14 dígitos")]
        public string Cnpj { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Razão Social é obrigatória")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string RazaoSocial { get; set; } = string.Empty;

        [StringLength(100)]
        public string NomeFantasia { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string EmailCorporativo { get; set; } = string.Empty;

        [StringLength(11)]
        public string Telefone { get; set; } = string.Empty;

        [StringLength(100)]
        public string ResponsavelTecnico { get; set; } = string.Empty;

        // --- CONFIGURAÇÃO DE INTEGRAÇÃO (TELA 2) ---
        // Aqui você adiciona os campos que aparecem no seu protótipo do Figma

        public string SistemasOrigem { get; set; } = string.Empty;
        public string SistemasDestino { get; set; } = string.Empty;
        public string VolumeDadosMensal { get; set; } = string.Empty;

        // --- ACESSIBILIDADE (TELA 3) ---

        public bool SuporteLibras { get; set; } // No banco é o BIT (0 ou 1)
        public bool NotificacoesEmail { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
