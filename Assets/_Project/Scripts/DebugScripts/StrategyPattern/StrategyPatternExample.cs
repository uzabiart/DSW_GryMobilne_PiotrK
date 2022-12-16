using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class StrategyPatternExample : SerializedMonoBehaviour
{
    public IItem item;

    [Button]
    public void UseItem()
    {
        item.Use();
    }
}

public interface IItem
{
    public abstract void Use();
}
public abstract class Item : IItem
{
    public abstract string itemName { get; }
    public abstract IUsable usable { get; }

    public void Use()
    {
        string description = $"{itemName} {usable.Use()}";
        Debug.Log(description);
    }
}

public class HealUp : IUsable
{
    public HealUp(ITarget target, IRange range, int amount)
    {
        this.amount = amount;
        this.target = target;
        this.range = range;
    }

    public int amount;
    public IRange range;
    public ITarget target;

    public string Use()
    {
        return $"heals {amount} hp, to {target.GetTarget()}. It can be used {range.GetRange()} range";
        // target.GetTarget(range).health.Heal(amount);
    }
}
public class DealDamage : IUsable
{
    public DealDamage(ITarget target, IRange range, IDamageType damageType, int damage)
    {
        this.damage = damage;
        this.damageType = damageType;
        this.range = range;
        this.target = target;
    }

    public int damage;
    public IDamageType damageType;
    public IRange range;
    public ITarget target;

    public string Use()
    {
        return $"deals {damage} damage, to {target.GetTarget()} and {damageType.ApplyDamageType(target)}. It can be used {range.GetRange()} range";
        // target.GetTarget(range).health.TakeDamage(damage, damageType);
    }
}

/// Range

public class MeleeRange : IRange
{
    public string GetRange()
    {
        return "only for melee";
        //Get targets that are only close
    }
}
public class LongRange : IRange
{
    public string GetRange()
    {
        return "for long";
        //Get targets that are far
    }
}

/// Targets

public class FriendlyTargets : ITarget
{
    public string GetTarget()
    {
        return "allies";
        //Get friendly targets
    }
}
public class EnemyTargets : ITarget
{
    public string GetTarget()
    {
        return "enemies";
        //Get enemy targets
    }
}
public class NPCTargets : ITarget
{
    public string GetTarget()
    {
        return "an NPC";
        //Get only non player targets
    }
}

/// DamageTypes

public class NormalDamage : IDamageType
{
    public string ApplyDamageType(ITarget target)
    {
        return "has no additional effect";
    }
}
public class FrostDamage : IDamageType
{
    public string ApplyDamageType(ITarget target)
    {
        return $"freezes the {target.GetTarget()}";
        //freeze the target
    }
}
public class SplashDamage : IDamageType
{
    public string ApplyDamageType(ITarget target)
    {
        return $"applies splash damage to {target.GetTarget()}";
        //deal damage too close targets
    }
}

/// Interfaces

public interface IUsable
{
    public string Use();
}
public interface IRange
{
    public string GetRange();
}
public interface ITarget
{
    public string GetTarget();
}
public interface IDamageType
{
    public string ApplyDamageType(ITarget target);
}


/// Items
/// 
public class Knife : Item
{
    public override string itemName => "Knife";
    public override IUsable usable => new DealDamage(new EnemyTargets(), new MeleeRange(), new NormalDamage(), 1);
}
public class FrozenThrowingKnife : Item
{
    public override string itemName => "Knife";
    public override IUsable usable => new DealDamage(new EnemyTargets(), new LongRange(), new FrostDamage(), 3);
}
public class Bandage : Item
{
    public override string itemName => "Bandage";
    public override IUsable usable => new HealUp(new FriendlyTargets(), new MeleeRange(), 1);
}
public class FrozenLauncher : Item
{
    public override string itemName => "FrozenLauncher";
    public override IUsable usable => new DealDamage(new EnemyTargets(), new LongRange(), new FrostDamage(), 9);
}

/// Memory Saver

public class Targets
{
    public static EnemyTargets enemies = new EnemyTargets();
    public static FriendlyTargets friendlies = new FriendlyTargets();
}
public class Ranges
{
    public static MeleeRange melee = new MeleeRange();
    public static LongRange longRange = new LongRange();
}
public class DamageTypes
{
    public static SplashDamage splash = new SplashDamage();
    public static FrostDamage frost = new FrostDamage();
}


///


public class User
{
    public PaymentMethod payment = new CreditCardPayment();

    void OnClick()
    {
        payment.Pay();
    }
}

public abstract class PaymentMethod
{
    public abstract void Pay();
}

public class PayPalPayment : PaymentMethod
{
    public override void Pay()
    {
        Debug.Log("Pay with paypal");
    }
}

public class CreditCardPayment : PaymentMethod
{
    public override void Pay()
    {
        Debug.Log("Pay with credit card");
    }
}