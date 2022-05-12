namespace EfCoreMigrationDemo.Entities;

public class Group
{
    public Group()
    {
        People = new HashSet<Person>();
    }

    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; }
}