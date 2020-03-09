using System;
using UnityEngine;

public class DropCheckLight : MonoBehaviour {
    
    private readonly Color colorNeeded = Color.green;

	public void Drop(Light lightToCheck)
    {
        if (lightToCheck == null)
            throw new ArgumentNullException("lightToCheck must not be null. Please assign the Spotlight to it.");
        if (lightToCheck.color != colorNeeded)
            throw new ArgumentException("lightToCheck doesn't have the right color. It must be " + colorNeeded.ToString() + ".");
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            if (t.name == "Floor")
            {
                t.gameObject.SetActive(false);
                return;
            }
        }
        throw new IndexOutOfRangeException("No floor was found in the children of " + name);
    }
}
