namespace EfCoreMigrationDemo.Entities;

public class PersonGroup
{
    public Guid PersonId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public Guid GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;
}