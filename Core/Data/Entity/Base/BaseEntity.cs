using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Data.Entity.Base;

public abstract class BaseEntity : BaseEntity<long>
{
}

public class BaseEntity<T> : AbstractEntiy

{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; }
}