using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip winEffect; 
    [SerializeField] private AudioClip loseEffect; 
    
    private AudioSource myAudioSource;
    
    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void TriggerWinSFX()
    {
        myAudioSource.PlayOneShot(winEffect);
    }
    
    public void TriggerLoseSFX()
    {
        myAudioSource.PlayOneShot(loseEffect);
    }
}
