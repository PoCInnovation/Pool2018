using UnityEngine;

public class PlayVictory : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip clip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clip = Resources.Load<AudioClip>("FF-Victory");
    }

    public void PlayMusic()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
