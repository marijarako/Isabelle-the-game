using UnityEngine;
using UnityEngine.Video;

public class TVPuzzleManager : MonoBehaviour
{
    public ColorSquare[] squares;
    public GameObject puzzlePanel;
    public GameObject staticOverlay;
    public VideoPlayer videoPlayer;
    public AudioSource wrongSound;
    public TVCutsceneManager cutsceneManager;
    public AudioSource tvAmbientSound;

    ColorType[] correctOrder =
    {
        ColorType.Yellow,
        ColorType.Green,
        ColorType.Blue,
        ColorType.Red
    };

    public void Confirm()
    {
        for (int i = 0; i < squares.Length; i++)
        {
            if (squares[i].currentColor != correctOrder[i])
            {
                wrongSound.Play();
                return;
            }
        }

        
        SolvePuzzle();
    }

    void SolvePuzzle()
    {
        puzzlePanel.SetActive(false);
        staticOverlay.SetActive(false);

        tvAmbientSound.Stop();
        videoPlayer.Play();

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cutsceneManager.StartCutscene();
    }

}
