using UnityEngine;

public class GlitchInteract : MonoBehaviour
{
    public GameObject phone;
    public GameObject glitchEffect;
    public AudioSource audioSource;
    public AudioClip glitchClickSound;

    public void Interact()
    {
        if (glitchClickSound != null)
            audioSource.PlayOneShot(glitchClickSound);

        glitchEffect.SetActive(false);
        phone.SetActive(true);
    }
}
