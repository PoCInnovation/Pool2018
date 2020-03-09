using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour {

    public enum classe
    {
        GUNNER,
        CANNONFODDER,
        SNIPER,
        RUNNER,
        SPECIALIST,
        BOSS
    }

    [Tooltip("Classe of the NPC.")]
    public classe myClasse;
    [Tooltip("UI to display NPC status. Set to null if none.")]
    public Text textUi;
    [Tooltip("End of the gun. Set to null if NPC have contact weapon.")]
    public Transform gunEnd;
    
    private const float backwardMultiplicator = 0.3f;
    private const float turnSpeed = 5.0f;
    private float reloadRef;

    private Rigidbody rb;
    private NPC me;
    private NPCManager npcManager;
    private LineRenderer lr;

    private void Fire()
    {
        if (reloadRef > 0.0f)
            return;
        if (lr == null)
            throw new System.ArgumentNullException("Fire action was called with a contact weapon.");
        if (textUi == null)
            throw new System.ArgumentNullException("NPC must have his gunEnd assigned to use a firearm.");
        lr.enabled = true;
        RaycastHit hit;

        Vector3 iniPos = gunEnd.position;
        Vector3 dir = gunEnd.forward
            + gunEnd.right * Random.Range(-me._precision, me._precision)
            + gunEnd.up * Random.Range(-me._precision, me._precision);
        lr.SetPosition(0, iniPos);
        Ray ray = new Ray(iniPos, dir);
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            //lr.SetPosition(1, hit.transform.position);
            NPCController npcc = hit.collider.GetComponent<NPCController>();
            if (npcc != null)
                npcc.TakeDamage(me._damage);
        }
        //else
        {
            lr.SetPosition(1, dir * 100);
        }
        reloadRef = me._reloadTime;
    }

    private void Start()
    {
        lr = GetComponentInChildren<LineRenderer>();
        npcManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<NPCManager>();
        switch (myClasse)
        {
            case classe.GUNNER:
                {
                    Alliee a = new Gunner(gameObject, npcManager);
                    npcManager.AddAlliee(a);
                    me = a;
                    break;
                }

            case classe.SNIPER:
                {
                    Alliee a = new Sniper(gameObject, npcManager);
                    npcManager.AddAlliee(a);
                    me = a;
                    break;
                }

            case classe.SPECIALIST:
                {
                    Alliee a = new Specialist(gameObject, npcManager);
                    npcManager.AddAlliee(a);
                    me = a;
                    break;
                }

            case classe.CANNONFODDER:
                {
                    Ennemy e = new CannonFodder(gameObject, npcManager);
                    npcManager.AddEnnemy(e);
                    me = e;
                    break;
                }

            case classe.RUNNER:
                {
                    Ennemy e = new Runner(gameObject, npcManager);
                    npcManager.AddEnnemy(e);
                    me = e;
                    break;
                }

            case classe.BOSS:
                {
                    Ennemy e = new Boss(gameObject, npcManager);
                    npcManager.AddEnnemy(e);
                    me = e;
                    break;
                }

            default:
                throw new System.ArgumentException("Invalid classe.");
        }
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(float value)
    {
        me.TakeDamage(value);
        if (!me.IsAlive())
        {
            npcManager.allEnnemies.Remove(me as Ennemy);
            npcManager.allAlliees.Remove(me as Alliee);
            Destroy(gameObject);
        }
    }

    public void Heal(float value)
    {
        me.Heal(value);
    }

    private void OnTriggerStay(Collider collider)
    {
        //   if (collision.collider.CompareTag("EnnemyWeapon"))
        if (name != "CannonFodder" && collider.name == "Spear")
        {
            TakeDamage(1);
        }
    }

    private void Update()
    {
        if (reloadRef > 0)
            reloadRef -= Time.deltaTime;
        if (lr != null)
            lr.enabled = false;
        NPC.Action action = me.Update();
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, action._yRot, 0.0f));
        switch (action._mov)
        {
            case NPC.movement.FORWARD:
                rb.velocity = transform.forward * me._speed;
                break;

            case NPC.movement.BACKWARD:
                rb.velocity = -transform.forward * me._speed * backwardMultiplicator;
                break;

            case NPC.movement.NONE:
                break;

            default:
                throw new System.ArgumentException("action.mov have an invalid value.");
        }
        if (action._doesFire)
            Fire();
        if (textUi != null)
            textUi.text = me.ToString();
    }

    public override string ToString()
    {
        return (me.ToString());
    }
}
