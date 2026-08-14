using UnityEngine;
using TMPro;

public class NumpadUI : MonoBehaviour
{
    public TMP_Text screenText;
    public PressKeyOpenDoor door;
    public PlayerMovement player;
    public AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip wrongSound;
    public AudioClip threeWrongSound;
    int wrongCount = 0;

    void OnEnable()
    {
        screenText.text = "ENTER CODE";
        Time.timeScale = 0f;

        if (player != null)
            player.LockPlayer();
        if (openSound != null)
            audioSource.PlayOneShot(openSound);
    }

    public void PressNumber(int number)
    {
        if (number == 0)
        {
            screenText.text = "OK";
            wrongCount = 0;
            Close();
            door.OpenDoor();
        }
        else
        {
            screenText.text = "ERROR";
            wrongCount++;

            if (wrongSound != null)
                audioSource.PlayOneShot(wrongSound);

            if (wrongCount >= 3 && threeWrongSound != null)
            {
                audioSource.PlayOneShot(threeWrongSound);
                wrongCount = 0;
            }
        }
    }

    public void Exit()
    {
        Close();
    }

    void Close()
    {
        Time.timeScale = 1f;

        if (player != null)
            player.UnlockPlayer(); 

        gameObject.SetActive(false);
    }
}
