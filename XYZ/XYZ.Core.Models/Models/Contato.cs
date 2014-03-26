namespace XYZ.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Contato")]
    public class Contato : Entity, Interfaces.Entities.IContatoEntity
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
