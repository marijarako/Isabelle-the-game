using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenTransition : MonoBehaviour
{
    public Image fadeImage;
    public TMP_Text text;
    public float fadeSpeed = 2f;
    public float textDuration = 2f;
    public AudioSource audioSource; 
    public AudioClip transitionSound;

    public void PlayTransition()
    {

        if (audioSource != null && transitionSound != null)
        {
            audioSource.PlayOneShot(transitionSound);
        }
        Color img = fadeImage.color;
        img.a = 0f;
        fadeImage.color = img;

        Color txt = text.color;
        txt.a = 0f;
        text.color = txt;

        text.text = "";

        gameObject.SetActive(true);
        StartCoroutine(TransitionRoutine());


    }

    IEnumerator TransitionRoutine()
    {
        
        yield return StartCoroutine(Fade(0f, 1f));

        
        text.text = "2 DAYS LEFT";
        yield return StartCoroutine(FadeText(0f, 1f));

        yield return new WaitForSeconds(textDuration);

        
        yield return StartCoroutine(FadeText(1f, 0f));

        
        yield return StartCoroutine(Fade(1f, 0f));

        gameObject.SetActive(false);
    }

    IEnumerator Fade(float from, float to)
    {
        float t = 0f;
        Color c = fadeImage.color;

        while (t < 1f)
        {
            t += Time.deltaTime * fadeSpeed;
            c.a = Mathf.Lerp(from, to, t);
            fadeImage.color = c;
            yield return null;
        }
    }

    IEnumerator FadeText(float from, float to)
    {
        float t = 0f;
        Color c = text.color;

        while (t < 1f)
        {
            t += Time.deltaTime * fadeSpeed;
            c.a = Mathf.Lerp(from, to, t);
            text.color = c;
            yield return null;
        }
    }
}
