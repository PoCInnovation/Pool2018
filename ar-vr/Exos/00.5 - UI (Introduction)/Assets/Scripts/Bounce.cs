using UnityEngine;

public class Bounce : MonoBehaviour {

    [Tooltip("Force of the bounce.")]
    public float bounceForce;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(new Vector3(0.0f, bounceForce, 0.0f), ForceMode.Impulse);
    }
}
