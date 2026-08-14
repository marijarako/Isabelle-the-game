using UnityEngine;

public class PhoneUIAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip openSound;

    void OnEnable()
    {
        if (openSound != null)
            audioSource.PlayOneShot(openSound);
    }
}