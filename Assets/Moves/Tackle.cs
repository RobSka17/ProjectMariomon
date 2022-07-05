using System;
using System.Collections.Generic;
using System.Linq;

public class Tackle: Move
{
    public Tackle()
    {
        Name = "Tackle";
        Description = "The user hurls their entire body at the target.";
        Type = Type.Normal;
        Power = 40;
        PP = 35;
        Category = MoveCategory.Physical;
    }

    public override void Use(Pokemon user, Battle battle, Pokemon[] targets)
    {
        int damage = CalculateDamage(user, battle, targets);
        targets[0].Damage(damage);
    }

    public override int CalculateDamage(Pokemon user, Battle battle, Pokemon[] targets)
    {
        int userAttackModifier = CalculateUserAttackModifier(user, battle);
        int targetDefenseModifier = CalculateTargetDefenseModifier(targets, battle);

        double damage = (((2 * user.Level / 5) + 2) * Power * (user.Attack + userAttackModifier) / (targets[0].Defense + targetDefenseModifier) / 50) + 2;
        
        if(Type == user.Type1 || Type == user.Type2)
        {
            damage *= user.StabMultiplier;
        }

        return Convert.ToInt32(Math.Floor(damage));
    }

    private int CalculateUserAttackModifier(Pokemon user, Battle battle)
    {
        List<StatModifier> statModifiers = battle.StatModifiers;
        StatModifier[] userStatModifiers = statModifiers.Where(s => s.AffectedPokemon == user).ToArray();
        StatModifier[] userAttackModifiers = userStatModifiers.Where(s => s.ModifiedStat == Stat.Attack).ToArray();

        int userAttackModifier = 0;
        for (int i = 0; i < userAttackModifiers.Length; i++)
        {
            userAttackModifier += userAttackModifiers[i].Amount;
        }

        return userAttackModifier;
    }

    private int CalculateTargetDefenseModifier(Pokemon[] targets, Battle battle)
    {
        List<StatModifier> statModifiers = battle.StatModifiers;
        StatModifier[] targetStatModifiers = statModifiers.Where(s => s.AffectedPokemon == targets[0]).ToArray();
        StatModifier[] targetDefenseModifiers = targetStatModifiers.Where(s => s.ModifiedStat == Stat.Defense).ToArray();

        int targetDefenseModifier = 0;
        for (int i = 0; i < targetDefenseModifiers.Length; i++)
        {
            targetDefenseModifier += targetDefenseModifiers[i].Amount;
        }

        return targetDefenseModifier;
    }
}
