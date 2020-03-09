using UnityEngine;

public class Elevator : MonoBehaviour {

    [Range(0.01f, 0.1f)]
    [Tooltip("Speed of the elevator when going up/down.")]
    public float translationSpeed;
    [Range(0.01f, 0.1f)]
    [Tooltip("Speed of the elevator when rotating.")]
    public float rotationSpeed;
    private float currSpeed;
    private bool enableRotation;
    private const float maxRotZ = -0.08824586f;
    private const float maxRotZGlobal = -10.125f;

    private void Start()
    {
        currSpeed = 0.0f;
        enableRotation = false;
    }

    public void Activate()
    {
        currSpeed = translationSpeed;
    }

    public void Stop()
    {
        currSpeed = 0.0f;
        enableRotation = true;
    }

    private void Update()
    {
        transform.Translate(new Vector3(0.0f, currSpeed, 0.0f));
        if (enableRotation)
        {
            if (transform.rotation.z > maxRotZ)
                transform.Rotate(new Vector3(0.0f, 0.0f, -rotationSpeed));
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, maxRotZGlobal));
                enableRotation = false;
            }
        }
    }
}
