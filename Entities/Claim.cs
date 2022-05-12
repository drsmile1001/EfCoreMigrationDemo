namespace EfCoreMigrationDemo.Entities;

public class Claim
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public string Type { get; set; } = null!;

    public string Value { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}