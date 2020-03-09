using UnityEngine;

public class FallingBonus : MonoBehaviour {

	public enum BonusType
    {
        HEALTH
    }

    public BonusType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NPCController npcc = other.GetComponent<NPCController>();
            if (npcc != null)
                npcc.Heal(25);
        }
    }
}
