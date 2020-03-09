using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class CheatException : Exception
{
    public CheatException(string message)
        : base(message)
    { }
}

public class CheatDetector : MonoBehaviour {

    NPCController.classe checkClasse(string classeName)
    {
        switch (classeName)
        {
            case "Gunner":
                return (NPCController.classe.GUNNER);

            case "Sniper":
                return (NPCController.classe.SNIPER);

            case "Specialist":
                return (NPCController.classe.SPECIALIST);

            default:
                throw new CheatException("Unknow classe name.");
        }
    }

    private bool isClasse(GameObject go, NPCController.classe classe)
    {
        NPCController npcc = go.GetComponent<NPCController>();
        if (npcc == null)
            return (false);
        return (checkClasse(npcc.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None)[0]) == classe);
    }

    private bool isGunner(GameObject go)
    {
        return (isClasse(go, NPCController.classe.GUNNER));
    }

    private bool isSniper(GameObject go)
    {
        return (isClasse(go, NPCController.classe.SNIPER));
    }

    private bool isSpecialist(GameObject go)
    {
        return (isClasse(go, NPCController.classe.SPECIALIST));
    }

    private void Start()
    {
        List<GameObject> allGos = FindObjectsOfType<GameObject>().ToList();
        if (allGos.Count(isGunner) != 1)
            throw new CheatException("There must be one and only one Gunner.");
        if (allGos.Count(isSniper) != 1)
            throw new CheatException("There must be one and only one Sniper.");
        if (allGos.Count(isSpecialist) != 1)
            throw new CheatException("There must be one and only one Specialist.");
    }
}
