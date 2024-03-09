using Core.Data.Enum;

namespace Core.Data.Entity.Base;

public class AbstractEntiy : IEntity
{
    public virtual RowStatus RowStatus { get; set; } = RowStatus.Active;
    public DateTime  CreatedAt { get; set; }
    public DateTime? Modified { get; set; }
    public DateTime? DeletedAt { get; set; }
    public virtual string SortBy(string sort)
    {
        return nameof(CreatedAt);
    }
}