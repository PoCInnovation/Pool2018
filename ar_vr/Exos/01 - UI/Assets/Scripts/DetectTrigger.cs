using System;
using UnityEngine;
using UnityEngine.Events;

public class DetectTrigger : MonoBehaviour {

    public UnityEvent triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered.GetPersistentEventCount() > 1)
            throw new ArgumentException("There can be only one event linked to triggered.");
        triggered.Invoke();
    }
}
