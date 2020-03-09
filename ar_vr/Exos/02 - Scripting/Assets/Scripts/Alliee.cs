using UnityEngine;

public abstract class Alliee : NPC {

    protected Alliee(GameObject go, NPCManager npcManager, float reloadTime, float damage, float speed, float precision)
        : base(go, npcManager, Hp.Alliee, reloadTime, damage, speed, precision)
    { }

    protected float minDist, maxDist;

    public override Action Update()
    {
        return (new Action(movement.NONE, false, 0f));
    }
}

public class Gunner : Alliee
{
    public Gunner(GameObject go, NPCManager npcManager)
        : base(go, npcManager, ReloadTime.Gunner, Damage.Gunner, MovementSpeed.Slow, ShootPrecisionMalus.MachineGun)
    {
    }

    public override string ToString()
    {
        return ("Gunner" + System.Environment.NewLine +
            _hp + "%");
    }
}

public class Specialist : Alliee
{
    public Specialist(GameObject go, NPCManager npcManager)
        : base(go, npcManager, ReloadTime.Specialist, Damage.Specialist, MovementSpeed.Normal, ShootPrecisionMalus.HandGun)
    {
    }

    public override string ToString()
    {
        return ("Specialist" + System.Environment.NewLine +
            _hp + "%");
    }
}

public class Sniper : Alliee
{
    public Sniper(GameObject go, NPCManager npcManager)
        : base(go, npcManager, ReloadTime.Sniper, Damage.Sniper, MovementSpeed.Slow, ShootPrecisionMalus.Sniper)
    {
    }

    public override string ToString()
    {
        return ("Sniper" + System.Environment.NewLine +
            _hp + "%");
    }
}
