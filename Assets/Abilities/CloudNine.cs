public class CloudNine: Ability
{
    public CloudNine()
    {
        Name = "Cloud Nine";
        Description = "Negates all weather effects.";
        Trigger = AbilityTrigger.Enter;
    }

    public override void Activate(Pokemon[] affectedPokemon, Battle battle)
    {
        battle.DisableWeatherEffects();
    }
}