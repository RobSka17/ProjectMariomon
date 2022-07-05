public class Ability
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public AbilityTrigger Trigger { get; protected set; }
    public virtual void Activate(Pokemon[] affectedPokemon, Battle battle) { }
}

public enum AbilityTrigger
{
    Enter,
    Attack,
}
