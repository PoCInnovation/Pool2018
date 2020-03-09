using System.Linq;
using UnityEngine;

public class Supressor : MonoBehaviour {

    [Tooltip("Tags who need to be ignored when checking collisions.")]
    public string[] exceptions;

    private void OnTriggerEnter(Collider other)
    {
        if (!exceptions.Any(x => x == other.tag))
            Destroy(other.gameObject);
    }
}
