using UnityEngine;

public class OpenDoor : MonoBehaviour {

    [Tooltip("The speed at which the door open")]
    [Range(0.01f, 0.1f)]
    public float speed;
    private bool doesBeginMove;
    private float maxY;

    public void activateMovement()
    {
        doesBeginMove = true;
        maxY = transform.position.y + 1;
    }

    private void Update()
    {
        if (doesBeginMove && transform.position.y < maxY)
            transform.Translate(new Vector3(0.0f, speed, 0.0f));
    }
}
