using UnityEngine;

public class ClockInteract : MonoBehaviour
{
    public GameObject interactUI;   
    public GameObject clockUI;     
    public AudioSource audioSource;
    public AudioClip openSound;

    bool playerLooking;

    void Update()
    {
        if (clockUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseClock();
            return;
        }

        if (playerLooking && Input.GetKeyDown(KeyCode.E))
        {
            OpenClock();
        }


    }

    void OpenClock()
    {
        clockUI.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (openSound != null)
            audioSource.PlayOneShot(openSound);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    public void CloseClock()
    {
        clockUI.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnMouseEnter()
    {
        interactUI.SetActive(true);
        playerLooking = true;
    }

    void OnMouseExit()
    {
        interactUI.SetActive(false);
        playerLooking = false;
    }

    public Collider clockCollider;

    public void DisableClock()
    {
        interactUI.SetActive(false);
        playerLooking = false;

        if (clockCollider != null)
            clockCollider.enabled = false;

        CloseClock();
    }
}