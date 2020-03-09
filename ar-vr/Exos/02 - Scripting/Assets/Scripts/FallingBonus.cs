using UnityEngine;

public class FallingBonus : MonoBehaviour {

	public enum BonusType
    {
        HEALTH
    }

    public BonusType type;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            NPCController npcc = collision.gameObject.GetComponent<NPCController>();
            if (npcc != null)
            {
                npcc.Heal(25);
                Destroy(gameObject);
            }
        }
    }
}
