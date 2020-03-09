using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public Transform toFollow { set; private get; }

    public Vector3 offset;

    private void Start()
    {
        toFollow = null;
    }

    private void Update()
    {
        if (toFollow == null)
            return;

        transform.position = toFollow.position + offset;
    }
}
