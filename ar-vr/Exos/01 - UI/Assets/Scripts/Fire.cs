using UnityEngine;

public class Fire : MonoBehaviour {

    [Range(1, 10)]
    [Tooltip("Time between 2 shoots")]
    public int reloadTime;
    [Range(10, 25)]
    [Tooltip("X velocity of a shoot")]
    public int fireXVel;
    [Tooltip("Barrel output")]
    public Transform barrelOutput;

    private float currTime;
    private GameObject bullet;

    private void Start()
    {
        bullet = Resources.Load("Bullet") as GameObject;
        if (barrelOutput.transform.position.x < transform.position.x)
            fireXVel *= -1;
    }

    void Update () {
        currTime += Time.deltaTime;
        if (currTime >= reloadTime && barrelOutput != null)
        {
            GameObject go = Instantiate(bullet, barrelOutput.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(new Vector3(fireXVel, 0.0f, 0.0f), ForceMode.Impulse);
            currTime = 0.0f;
        }
    }
}
