using System;

public class Psyduck: Pokemon
{
    public Psyduck(int level)
    {
        Name = "Psyduck";
        Level = level;
        Moves = new Move[] { new Tackle(), new Move(), new Move(), new Move() };
        Type1 = Type.Water;
        Type2 = Type.None;
        Ability = new CloudNine();
        StabMultiplier = 1.5;
        MaxHP = CalculateMaxHP();
        CurrentHP = MaxHP;
        HPGain = 0;
        Attack = CalculateAttack();
        AttackGain = 0;
        Defense = CalculateDefense();
    }

    private const int BaseHP = 50;
    private const int BaseAttack = 52;
    private const int BaseDefense = 48;
    private const int BaseSpecialAttack = 65;
    private const int BaseSpecialDefense = 50;
    private const int BaseSpeed = 55;

    private int CalculateMaxHP()
    {
        return Level * 2 + HPGain * BaseHP / 100 + (Level / 2);
    }

    private int CalculateAttack()
    {
        return Convert.ToInt32(Math.Floor(Level * 1.5 + AttackGain * BaseAttack / 100 + (Level / 2)));
    }

    private int CalculateDefense()
    {
        return Convert.ToInt32(Math.Floor(Level * 1.5 + DefenseGain * BaseDefense / 100 + (Level / 2)));
    }

    public void GenerateId()
    {
        Id = new Guid();
    }

    public int GetDexNumber()
    {
        return 104;
    }
}
