using System;
using UnityEngine;

public class ImpulseTowards : MonoBehaviour {

    [Tooltip("Objectif the impulse will aim.")]
    public GameObject objective;

    private const float impulseForce = 0.25f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (objective == null)
            throw new ArgumentException("objective is null.");
        float impulseX = 0.0f;
        float impulseY = 0.0f;
        if (transform.position.x > objective.transform.position.x)
            impulseX = -impulseForce;
        if (transform.position.x < objective.transform.position.x)
            impulseX = impulseForce;
        if (transform.position.y > objective.transform.position.y)
            impulseY = -impulseForce;
        if (transform.position.y < objective.transform.position.y)
            impulseY = impulseForce;
        rb.AddForce(new Vector3(impulseX, impulseY, 0.0f), ForceMode.Impulse);
    }
}
