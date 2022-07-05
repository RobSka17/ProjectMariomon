public class Adaptability: Ability
{
    public Adaptability()
    {
        Name = "Adaptability";
        Description = "Boosts same type attack bonus.";
        Trigger = AbilityTrigger.Attack;
    }

    public void Effect(Pokemon[] affectedPokemon, Battle battle)
    {
        affectedPokemon[0].SetStabMultiplier(2);
    }
}