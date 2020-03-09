using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DisableCollider : MonoBehaviour {

    [Tooltip("Tags to ignore when checking collisions.")]
    public string[] toIgnore;

    private bool isTrigger;
    private BoxCollider bc;

    private void Start()
    {
        isTrigger = false;
        bc = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isTrigger && !toIgnore.Contains(collision.gameObject.tag))
        {
            bc.isTrigger = true;
            isTrigger = true;
        }
    }
}
