public class Item
{
    public enum ItemCategory
    {
        Medicine,
        Balls
    }

    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public ItemCategory Category { get; protected set; }
}
