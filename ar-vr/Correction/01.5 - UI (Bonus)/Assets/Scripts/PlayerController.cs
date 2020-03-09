using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : NetworkBehaviour {

    public float speed;

    private Rigidbody rb;

    private void Start()
    {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        if (!isLocalPlayer)
            return;
        rb = GetComponent<Rigidbody>();
        Camera.main.GetComponent<FollowTarget>().toFollow = transform;
    }

    private void Update()
    {
         if (!isLocalPlayer)
           return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(0f, 10f, 0f);
            rb.velocity = Vector3.zero;
        }
    }
}
