namespace Eventflix.Api.Application.Organizations;

public class Organization
{
    private Organization() { }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Guid ManagerId { get; private set; }

    public static Organization Create(string name, Guid managerId)
    {
        return new Organization
        {
            Name = name,
            ManagerId = managerId
        };
    }

    public void Update(string name)
    {
        Name = name;
    }
}
