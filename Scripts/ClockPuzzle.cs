using System.Collections;
using UnityEngine;

public class ClockPuzzle : MonoBehaviour
{
    public RectTransform hourHand;
    public RectTransform minuteHand;

    public int hour = 12;
    public int minute = 0;

    [Header("Confirm")]
    public AudioSource audioSource;
    public AudioClip wrongSound;
    public AudioClip correctSound;

    public InventoryItem clockItem; 
    public ClockInteract clockInteract;

    [Header("Wrong Attempt Settings")]
    public AudioClip wrongAttempt2Sound;  
    public AudioClip wrongAttempt5Sound;  
    public int wrongAttempts = 0;

    [Header("Warning Panel Settings")]
    public GameObject warningPanel;
    public GameObject nextPanel; 
    public AudioClip warningPanelCloseAudio;

    bool solved = false;

    void Start()
    {
        UpdateHands();
    }

    public void HourUp()
    {
        hour = (hour + 1) % 12;
        UpdateHands();
    }

    public void HourDown()
    {
        hour = (hour - 1 + 12) % 12;
        UpdateHands();
    }

    public void MinuteUp()
    {
        minute = (minute + 5) % 60;
        UpdateHands();
    }

    public void MinuteDown()
    {
        minute = (minute - 5 + 60) % 60;
        UpdateHands();
    }

    public void Confirm()
    {
        if (solved) return;

        if (hour == 6 && minute == 20)
        {
            solved = true;

            GameFlags.ClockPuzzleSolved = true;

            FindObjectOfType<InventoryManager>().AddItem(clockItem);

            if (correctSound != null)
                audioSource.PlayOneShot(correctSound);

            clockInteract.CloseClock();
            clockInteract.DisableClock();
        }
        else
        {
            wrongAttempts++;

            
            if (wrongSound != null)
                audioSource.PlayOneShot(wrongSound);

            
            if (wrongAttempts == 2 && wrongAttempt2Sound != null)
                audioSource.PlayOneShot(wrongAttempt2Sound);
            else if (wrongAttempts == 5 && wrongAttempt5Sound != null)
            {
                StartCoroutine(ShowWarningPanelAfterAudio(wrongAttempt5Sound));
            }
        }
    }

    void UpdateHands()
    {
        float minuteAngle = -minute * 6f;
        float hourAngle = -(hour * 30f + minute * 0.5f);

        minuteHand.localRotation = Quaternion.Euler(0, 0, minuteAngle);
        hourHand.localRotation = Quaternion.Euler(0, 0, hourAngle);
    }

    public void YesButtonClicked()
    {
        if (nextPanel != null)
            nextPanel.SetActive(true);

        if (warningPanel != null)
            warningPanel.SetActive(false);

        StartCoroutine(HideNextPanelAfterDelay(5f));


    }

    public void NoButtonClicked()
    {
        if (warningPanel != null)
            warningPanel.SetActive(false);

        if (warningPanelCloseAudio != null)
            audioSource.PlayOneShot(warningPanelCloseAudio);
    }
    private IEnumerator ShowWarningPanelAfterAudio(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();

            
            while (audioSource.isPlaying)
                yield return null;
        }

        
        if (warningPanel != null)
            warningPanel.SetActive(true);
    }

    private IEnumerator HideNextPanelAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        if (nextPanel != null)
            nextPanel.SetActive(false);
    }


}
