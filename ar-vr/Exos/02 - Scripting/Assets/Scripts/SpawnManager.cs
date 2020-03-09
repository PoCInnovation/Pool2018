using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {

    public GameObject[] toSpawn;
    public Transform[] spawns;
    public float spawnIntervalle;
    public Text waveDisplay;
    public int currentWave { set; get; }
    private float timeRef;

    public GameObject[] endWaveBonus;

    private void Start()
    {
        currentWave = 0;
        timeRef = spawnIntervalle;
    }

    public void SpawnBonus(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject bonus = endWaveBonus[Random.Range(0, endWaveBonus.Length)];
            Vector3 pos = new Vector3(Random.Range(-50.0f, 50.0f), 25.0f, Random.Range(-50.0f, 50.0f));
            GameObject go = Instantiate(bonus, pos, Quaternion.identity);
            go.name = bonus.name;
        }
    }

    private void SpawnEnnemies()
    {
        if (toSpawn.Length < 1)
            throw new System.ArgumentException("There must be at least 1 classe to spawn.");
        //sm.currentWave++;
        SpawnBonus(1);
        //sm.displayCurrentWaveMessage();
        foreach (Transform t in spawns)
        {
            GameObject ennemyToSpawn = toSpawn[Random.Range(0, toSpawn.Length)];
            GameObject go = Instantiate(ennemyToSpawn, t.position, Quaternion.identity);
            go.name = ennemyToSpawn.name;
            go.transform.position = new Vector3(go.transform.position.x, 1.0f, go.transform.position.z);
        }
    }

    private void Update()
    {
        timeRef -= Time.deltaTime;
        if (timeRef <= 0.0f)
        {
            SpawnEnnemies();
            timeRef = spawnIntervalle;
        }
    }

    public void displayCurrentWaveMessage()
    {
        waveDisplay.text = "Wave " + currentWave + ':' + System.Environment.NewLine;
        /*switch (currentWave)
        {
            case 1:
                waveDisplay.text += "Runners are coming!";
                break;

            case 2:
                waveDisplay.text += "Bosses are coming!";
                break;

            default:
                waveDisplay.text += "More ennemies are comming...";
                break;
        }*/
    }
}
