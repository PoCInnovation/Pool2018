using UnityEngine;

public abstract class Ennemy : NPC
{
    protected Ennemy(GameObject go, NPCManager npcManager, float hp, float damage, float speed)
        : base(go, npcManager, hp, ReloadTime.Ennemy, damage, speed, ShootPrecisionMalus.ContactWeapon)
    { }

    public override Action Update()
    {
        Alliee target = GetClosest(_npcManager.allAlliees);
        if (target != null)
            return (new Action(movement.FORWARD, false, GetLookRotation(target)));
        else
            return (new Action(movement.NONE, false, 0.0f));
    }
}

public class CannonFodder : Ennemy
{
    public CannonFodder(GameObject go, NPCManager npcManager)
        : base(go, npcManager, Hp.RegularEnnemy, Damage.CannonFodder, MovementSpeed.Normal)
    { }

    public override string ToString()
    {
        return ("CannonFodder" + System.Environment.NewLine +
            _hp + "%");
    }
}

public class Runner : Ennemy
{
    public Runner(GameObject go, NPCManager npcManager)
        : base(go, npcManager, Hp.SmallEnnemy, Damage.CannonFodder, MovementSpeed.Fast)
    { }

    public override string ToString()
    {
        return ("Runner" + System.Environment.NewLine +
            _hp + "%");
    }
}

public class Boss : Ennemy
{
    public Boss(GameObject go, NPCManager npcManager)
        : base(go, npcManager, Hp.Boss, Damage.CannonFodder, MovementSpeed.Slow)
    { }

    public override string ToString()
    {
        return ("Boss" + System.Environment.NewLine +
            _hp + "%");
    }
}
