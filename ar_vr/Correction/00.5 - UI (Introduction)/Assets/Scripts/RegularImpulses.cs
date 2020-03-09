using UnityEngine;

public class RegularImpulses : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    [Tooltip("Force of the impulses.")]
    public float impulseForce;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.AddForce(new Vector3(0.0f, impulseForce, 0.0f), ForceMode.Impulse);
    }
}
