using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TVCutsceneManager : MonoBehaviour
{
    [Header("Player")]
    public PlayerMovement playerMovement;
    public Transform player;
    public Camera playerCamera;

    [Header("Teleport")]
    public Transform teleportPoint;

    [Header("Camera Rotations")]
    public Vector3 startCameraRotation;
    public Vector3 endCameraRotation;

    [Header("Scene Objects")]
    public GameObject objectToHide;

    [Header("UI Screens")]
    public CanvasGroup fadeScreen;
    public GameObject thankYouScreen;
    public GameObject demoScreen;
    public GameObject creditsScreen;

    [Header("Timing")]
    public float watchVideoTime = 23f;
    public float cameraMoveTime = 5f;
    public float afterMoveDelay = 5f;

    public void StartCutscene()
    {
        StartCoroutine(CutsceneRoutine());
    }

    IEnumerator CutsceneRoutine()
    {

        playerMovement.LockPlayer();


        player.position = teleportPoint.position;
        player.rotation = teleportPoint.rotation;


        playerCamera.transform.localRotation = Quaternion.Euler(startCameraRotation);


        yield return new WaitForSeconds(watchVideoTime);


        yield return StartCoroutine(MoveCamera());


        objectToHide.SetActive(false);

        yield return new WaitForSeconds(afterMoveDelay);


        yield return StartCoroutine(FadeToBlack());

        thankYouScreen.SetActive(true);
        yield return new WaitForSeconds(4f);

        demoScreen.SetActive(true);
        yield return new WaitForSeconds(4f);

        creditsScreen.SetActive(true);

        creditsScreen.SetActive(true);

        yield return new WaitForSeconds(5f);
        QuitGame();
    }

    IEnumerator MoveCamera()
    {
        Quaternion startRot = playerCamera.transform.localRotation;
        Quaternion endRot = Quaternion.Euler(endCameraRotation);

        float t = 0;

        while (t < cameraMoveTime)
        {
            t += Time.deltaTime;
            playerCamera.transform.localRotation =
                Quaternion.Lerp(startRot, endRot, t / cameraMoveTime);

            yield return null;
        }
    }

    IEnumerator FadeToBlack()
    {
        float t = 0;

        while (t < 1f)
        {
            t += Time.deltaTime;
            fadeScreen.alpha = t;
            yield return null;
        }
    }
    void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
