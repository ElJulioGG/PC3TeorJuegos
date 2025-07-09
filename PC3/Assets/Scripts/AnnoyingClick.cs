using UnityEngine;
using UnityEngine.Audio;

public class AnnoyingClick : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        
    }

    void Update()
    {

    }
    public void playThisSFX()
    {
        audioSource.Play();
    }
}
