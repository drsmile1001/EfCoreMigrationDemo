namespace EfCoreMigrationDemo.Entities;

public class Person
{
    public Person()
    {
        Groups = new HashSet<Group>();
        Claims = new HashSet<Claim>();
    }

    public Guid Id { get; set; }

    public string NickName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; }

    public virtual ICollection<Claim> Claims { get; set; }
}
