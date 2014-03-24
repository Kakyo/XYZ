namespace XYZ.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Parceiro : Entity, Interfaces.Entities.IParceiroEntity
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string CpfCnpj { get; set; }

        public long? IdResponsavel { get; set; }
        [ForeignKey("IdResponsavel")]
        public Interfaces.Entities.IParceiroEntity Responsavel { get; set; }
    }
}
