using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    public List<Alliee> allAlliees;
    public List<Ennemy> allEnnemies;

    private void Start()
    {
        allAlliees = new List<Alliee>();
        allEnnemies = new List<Ennemy>();
    }

    public void AddAlliee(Alliee npc)
    {
        allAlliees.Add(npc);
    }

    public void AddEnnemy(Ennemy npc)
    {
        allEnnemies.Add(npc);
    }
}
