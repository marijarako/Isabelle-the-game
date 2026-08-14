using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroSequence : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement playerMovement;
    public Image blackScreen;
    public Camera playerCamera;
    public AudioSource audioSource;

    [Header("Audio")]
    public AudioClip wakeUpClip;
    public AudioClip dialogueClip;

    [Header("UI")]
    public GameObject instructionPanel;
    public CanvasGroup instructionCanvas;

    [Header("Camera Heights")]
    public float groundCameraHeight = 0.25f;
    public float standingCameraHeight = 1.6f;
    public float standUpDuration = 3f;

    void Start()
    {
        playerMovement.LockPlayer();
        StartCoroutine(IntroRoutine());
    }

    IEnumerator IntroRoutine()
    {
       
        blackScreen.color = new Color(0, 0, 0, 1);

        
        playerMovement.LockPlayer();

        
        audioSource.PlayOneShot(wakeUpClip);

        
        yield return new WaitForSeconds(wakeUpClip.length);

       
        Vector3 camPos = playerCamera.transform.localPosition;
        camPos.y = groundCameraHeight;
        playerCamera.transform.localPosition = camPos;

        
        float timer = 0f;

        while (timer < standUpDuration)
        {
            timer += Time.deltaTime;
            float t = timer / standUpDuration;

            
            blackScreen.color = new Color(0, 0, 0, 1 - t);

            
            float y = Mathf.Lerp(groundCameraHeight, standingCameraHeight, t);
            playerCamera.transform.localPosition = new Vector3(0, y, 0);

            yield return null;
        }

      
        blackScreen.color = new Color(0, 0, 0, 0);
        playerCamera.transform.localPosition = new Vector3(0, standingCameraHeight, 0);

        
        playerMovement.UnlockPlayer();

       
        audioSource.PlayOneShot(dialogueClip);

       
        instructionPanel.SetActive(true);
        instructionCanvas.alpha = 1;

        yield return new WaitForSeconds(4f);

      
        while (instructionCanvas.alpha > 0)
        {
            instructionCanvas.alpha -= Time.deltaTime;
            yield return null;
        }

        instructionPanel.SetActive(false);
    }

    IEnumerator Blink()
    {
        
        for (float a = 1; a >= 0; a -= Time.deltaTime * 3)
        {
            blackScreen.color = new Color(0, 0, 0, a);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

      
        for (float a = 0; a <= 1; a += Time.deltaTime * 3)
        {
            blackScreen.color = new Color(0, 0, 0, a);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
    }
}
