using UnityEngine;

public abstract class Alliee : NPC {

    protected Alliee(GameObject go, NPCManager npcManager, float reloadTime, float damage, float speed, float precision)
        : base(go, npcManager, Hp.Alliee, reloadTime, damage, speed, precision)
    { }

    protected float minDist, maxDist;

    public override Action Update()
    {
        if (_npcManager.allEnnemies.Count == 0)
            return (new Action(movement.NONE, false, 0.0f));
        Ennemy target = GetClosest(_npcManager.allEnnemies);
        if (target == null)
            return (new Action(movement.NONE, false, 0.0f));
        movement mov;
        float dist = GetDistance(target);
        if (dist < minDist)
            mov = movement.BACKWARD;
        else if (dist > maxDist)
            mov = movement.FORWARD;
        else
            mov = movement.NONE;
        return (new Action(mov, true, GetLookRotation(target)));
    }
}

public class Gunner : Alliee
{
    public Gunner(GameObject go, NPCManager npcManager)
        : base(go, npcManager, ReloadTime.Gunner, Damage.Gunner, MovementSpeed.Slow, ShootPrecisionMalus.MachineGun)
    {
        minDist = 5;
        maxDist = 10;
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
        minDist = 10;
        maxDist = 20;
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
        minDist = 20;
        maxDist = 30;
    }

    public override string ToString()
    {
        return ("Sniper" + System.Environment.NewLine +
            _hp + "%");
    }
}
