using System.Collections.Generic;
using UnityEngine;

public abstract class NPC {

    protected NPC(GameObject go, NPCManager npcManager, float hp, float reloadTime, float damage, float speed, float precision)
    {
        _me = go;
        _npcManager = npcManager;
        _hpMax = hp;
        _hp = hp;
        _reloadTime = reloadTime;
        _damage = damage;
        _speed = speed;
        _precision = precision;
    }

    public abstract Action Update();

    protected readonly GameObject _me;
    protected readonly NPCManager _npcManager;
    public readonly float _reloadTime;
    public readonly float _damage;
    public readonly float _speed;
    public readonly float _precision;
    protected float _hp { private set; get; }
    protected readonly float _hpMax;

    public enum movement
    {
        NONE,
        FORWARD,
        BACKWARD
    }

    public struct Action
    {
        public Action(movement mov, bool doesFire, float yRot)
        {
            _mov = mov;
            _doesFire = doesFire;
            _yRot = yRot;
        }
        public movement _mov { private set; get; }
        public bool _doesFire { private set; get; }
        public float _yRot { private set; get; }
    }

    public void TakeDamage(float value)
    {
        _hp -= value;
    }

    public void Heal(float value)
    {
        _hp += value;
        if (_hp > _hpMax)
            _hp = _hpMax;
    }

    public bool IsAlive()
    {
        return (_hp > 0);
    }

    protected float GetDistance(NPC npc)
    {
        if (npc == null)
            throw new System.ArgumentNullException("npc is null.");
        return (Vector3.Distance(_me.transform.position, npc._me.transform.position));
    }

    protected float GetLookRotation(NPC npc)
    {
        if (npc == null)
            throw new System.ArgumentNullException("npc is null.");
        Vector3 dir = (npc._me.transform.position - _me.transform.position).normalized;
        return (Quaternion.LookRotation(dir).eulerAngles.y);
    }

    protected T GetClosest<T>(List<T> npcs)
        where T : NPC
    {
        float distance;
        return (GetClosest(npcs, out distance));
        // return (GetClosest(npcs, out _)); // C# 7 not supported by Unity yet
    }

    protected T GetClosest<T>(List<T> npcs, out float distance)
        where T : NPC
    {
        if (npcs == null || npcs.Count == 0)
        {
            throw new System.ArgumentNullException("npc is null.");
        }
        T closest = null;
        distance = 0f;
        foreach (T npc in npcs)
        {
            if (npc == this)
                continue;
            float currDistance = GetDistance(npc);
            if (closest == null || currDistance < distance)
            {
                closest = npc;
                distance = currDistance;
            }
        }
        return (closest);
    }

    protected struct ReloadTime
    {
        public const float Ennemy = 0.0f;
        public const float Gunner = 0.05f;
        public const float Specialist = 0.3f;
        public const float Sniper = 2.0f;
    }

    protected struct Damage
    {
        public const float Gunner = 0.3f;
        public const float CannonFodder = 1f;
        public const float Specialist = 1f;
        public const float Sniper = 20f;
    }

    protected struct MovementSpeed
    {
        public const float Slow = 1.0f;
        public const float Normal = 3.0f;
        public const float Fast = 7.0f;
    }

    protected struct Hp
    {
        public const float Alliee = 100f;
        public const float Boss = 75f;
        public const float RegularEnnemy = 5f;
        public const float SmallEnnemy = 2f;
    }

    protected struct ShootPrecisionMalus
    {
        public const float ContactWeapon = 0.0f;
        public const float MachineGun = 0.1f;
        public const float HandGun = 0.01f;
        public const float Sniper = 0.001f;
    }
}
