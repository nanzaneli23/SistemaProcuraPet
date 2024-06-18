using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoProcura.Models
{
    public class Observacoes
    {
        [Column("ObservacoesId")]
        [Display(Name = "Código das Observações")]

        public int ObservacoesId { get; set; }

        [Column("ObservacoesDescricao")]
        [Display(Name = "Descrição das Observações")]
        public string ObservacoesDescricao { get; set; } = string.Empty;

        [Column("ObservacoesLocal")]
        [Display(Name = "Local das Observações")]
        public string ObservacoesLocal { get; set; } = string.Empty;

        [Column("ObservacoesData")]
        [Display(Name = "Data das observações")]
        public DateTime  ObservacoesData { get; set; }

        [ForeignKey("AnimalId")]
        public int AnimalId { get; set; }

        public Animal? Animal { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }


    }
}
