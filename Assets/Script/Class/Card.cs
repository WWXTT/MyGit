/// <summary>
/// ¿¨ÅÆ³éÏóÀà
/// </summary>
public abstract class Card
{
    string id;
    string name;
    string desc;

    public string Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Desc { get => desc; set => desc = value; }
}
