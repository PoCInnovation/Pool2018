using System.Linq;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {

    [Tooltip("Tags who need to be ignored when checking collisions.")]
    public string[] exceptions;

    private void OnCollisionEnter(Collision collision)
    {
        if (!exceptions.Any(x => x == collision.gameObject.tag))
            Destroy(gameObject);
    }
}
