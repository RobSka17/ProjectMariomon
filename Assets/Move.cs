public class Move
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public Type Type { get; protected set; }
    public int Power { get; protected set; }
    public int Accuracy { get; protected set; }
    public int PP { get; protected set; }
    public MoveCategory Category { get; protected set; }
    public virtual void Use(Pokemon user, Battle battle, Pokemon[] targets) { }
    public virtual int CalculateDamage(Pokemon user, Battle battle, Pokemon[] targets) { return 0; }
}

public enum MoveCategory
{
    Physical,
    Special,
    Status
}