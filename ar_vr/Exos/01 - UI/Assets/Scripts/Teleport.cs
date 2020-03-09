using System;
using UnityEngine;

public class Teleport : MonoBehaviour {

    [Tooltip("Where the object entering the teleporter should be teleported")]
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if (destination == null)
            throw new ArgumentNullException("destionation must not be null.");
        if (destination.name != "TeleporterOutput")
            throw new ArgumentException("destination must be a TeleporterOutput.");
        other.transform.position = destination.position;
    }
}
