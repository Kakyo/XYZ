namespace XYZ.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Entity : Interfaces.Entities.IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime DtCreation { get; set; }
        public long IdUserCreation { get; set; }
        public DateTime DtModified { get; set; }
        public long IdUserModified { get; set; }
    }
}
