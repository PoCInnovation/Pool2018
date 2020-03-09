using UnityEngine;

public class RenderSpring : MonoBehaviour {

    [Tooltip("Position of the end of the spring")]
    public Transform SpringEnd;
    private LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, transform.position);
    }

    void Update () {

        lr.SetPosition(1, SpringEnd.position);
    }
}
