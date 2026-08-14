using UnityEngine;

public class GlitchCubeInteract : MonoBehaviour
{
    public AudioClip interactSound;

    public void Interact(AudioSource audioSource)
    {
        if (interactSound != null)
        {
            audioSource.PlayOneShot(interactSound);
        }
    }
}
