using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoProcura.Models
{
    [Table("Animal")]
    public class Animal
    {

        [Column("AnimalId")]
        [Display(Name = "Código do Animal")]

        public int AnimalId { get; set; }

        [Column("NomeAnimal")]
        [Display(Name = "Nome do Animal")]
        public string NomeAnimal { get; set; } = string.Empty;

        [Column("AnimalRaca")]
        [Display(Name = "Raça do Animal")]
        public string AnimalRaca { get; set; } = string.Empty;

        [Column("AnimalTipo")]
        [Display(Name = "Tipo do Animal")]
        public string AnimalTipo { get; set; } = string.Empty;

        [Column("AnimalCor")]
        [Display(Name = "Cor do Animal")]
        public string AnimalCor { get; set; } = string.Empty;

        [Column("AnimalSexo")]
        [Display(Name = "Sexo do Animal")]
        public string AnimalSexo { get; set; } = string.Empty;

        [Column("AnimalObservacao")]
        [Display(Name = "Observação do Animal")]
        public string AnimalObservacao { get; set; } = string.Empty;

        [Column("AnimalFoto")]
        [Display(Name = "Foto do Animal")]
        public string AnimalFoto { get; set; } = string.Empty;

        [Column("AnimalDtDesaperecimento")]
        [Display(Name = "Data do desaparecimento do Animal")]
        public DateTime AnimalDtDesaparecimento { get; set; }

        [Column("AnimalDtEncontro")]
        [Display(Name = "Data de encontro do Animal")]
        public DateTime ? AnimalDtEncontro { get; set; }

        [Column("AnimalStatus")]
        [Display(Name = "Status do Animal")]
        public byte AnimalStatus { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

    }
}