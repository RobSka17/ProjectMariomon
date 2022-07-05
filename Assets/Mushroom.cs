public class Mushroom: Item
{
    public const int HealAmount = 20;

    public Mushroom()
    {
        Name = "Mushroom";
        Description = "Consume to restore 20 health.";
        Category = ItemCategory.Medicine;
    }
}