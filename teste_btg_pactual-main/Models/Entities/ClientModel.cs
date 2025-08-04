namespace ClientCRUD.Models.Entities;
public class ClientModel : BaseObject
{
    public static readonly string tableName = "clients.json";
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public int? Age { get; set; }
    public string DefaultProperty
    {
        get { return $"{Name} {LastName}"; }
    }
    public ClientModel() { }
}
