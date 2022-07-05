using System;

public class Pokemon
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public int Level { get; protected set; }
    public int MaxHP { get; protected set; }
    public int HPGain { get; protected set; }
    public int CurrentHP { get; protected set; }
    public int Attack { get; protected set; }
    public int AttackGain { get; protected set; }
    public int Defense { get; protected set; }
    public int DefenseGain { get; protected set; }
    public int SpecialAttack { get; protected set; }
    public int SpecialDefense { get; protected set; }
    public int Speed { get; protected set; }
    public Move[] Moves { get; protected set; }
    public Type Type1 { get; protected set; }
    public Type Type2 { get; protected set; }
    public Ability Ability { get; protected set; }
    public double StabMultiplier { get; protected set; }
    public void Damage(int damageAmount)
    {
        if(CurrentHP < damageAmount)
        {
            CurrentHP = 0;
        }
        else
        {
            CurrentHP -= damageAmount;
        }
    }
    public void SetStabMultiplier(double newValue)
    {
        StabMultiplier = newValue;
    }
}
