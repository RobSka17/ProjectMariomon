public class StatModifier
{
    public StatModifier(Pokemon pokemon, Stat stat, int amount)
    {
        AffectedPokemon = pokemon;
        ModifiedStat = stat;
        Amount = amount;
    }

    public Pokemon AffectedPokemon { get; private set; }
    public Stat ModifiedStat { get; private set; }
    public int Amount { get; private set; }
}

public enum Stat
{
    Attack,
    Defense,
    SpecialAttack,
    SpecialDefense,
    Speed
}
