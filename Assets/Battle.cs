using System.Collections.Generic;

public class Battle
{
    public BattlePhase Phase { get; private set; }
    public int TurnNumber { get; private set; }
    public bool WeatherEffectsEnabled { get; private set; }
    public List<StatModifier> StatModifiers { get; private set; }
    public Pokemon[] enteredPokemon { get; private set; }

    public Battle()
    {
        Phase = BattlePhase.Enter;
        TurnNumber = 0;
        enteredPokemon = new Pokemon[] { new Pokemon(), new Pokemon(), new Pokemon(), new Pokemon() };
        WeatherEffectsEnabled = true;
        StatModifiers = new List<StatModifier>();
    }

    public void EnterPokemon(Pokemon pokemon, int position)
    {
        enteredPokemon.SetValue(pokemon, position);
    }

    public void EnableWeatherEffects()
    {
        WeatherEffectsEnabled = true;
    }

    public void DisableWeatherEffects()
    {
        WeatherEffectsEnabled = false;
    }

    public void SetBattlePhase(BattlePhase phase)
    {
        Phase = phase;
    }
}

public enum BattlePhase
{
    Enter,
    ActionSelection,
    ItemSelection
}
