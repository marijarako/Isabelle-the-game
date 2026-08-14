using UnityEngine;

public class VolleyballInteract : MonoBehaviour
{

    public GameObject ballUIPanel;
    public InventoryItem ballItem;

    public AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip closeSound;

    

    bool openedOnce = false;

    void OnMouseDown()
    {
        OpenBallUI();
    }

    void OpenBallUI()
    {
        ballUIPanel.SetActive(true);
        Time.timeScale = 0f;

        if (openSound != null)
            audioSource.PlayOneShot(openSound);
    }

    public void CloseBallUI()
    {
        ballUIPanel.SetActive(false);
        Time.timeScale = 1f;

        if (closeSound != null)
            audioSource.PlayOneShot(closeSound);

        if (!openedOnce)
        {
            openedOnce = true;

            FindObjectOfType<InventoryManager>().AddItem(ballItem);
            gameObject.SetActive(false);

            
            

            
            
        }
    }
}
