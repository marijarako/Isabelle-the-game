using UnityEngine;

public class TVInteract : MonoBehaviour
{
    public GameObject interactText;
    public GameObject puzzlePanel;

    bool puzzleOpen = false;

    void Start()
    {
        interactText.SetActive(false);
    }

    void Update()
    {
        if (!puzzleOpen) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePuzzle();
        }
    }

    void OnMouseEnter()
    {
        if (!puzzleOpen)
            interactText.SetActive(true);
    }

    void OnMouseExit()
    {
        interactText.SetActive(false);
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E) && !puzzleOpen)
        {
            OpenPuzzle();
        }
    }

    void OpenPuzzle()
    {
        puzzlePanel.SetActive(true);
        puzzleOpen = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        interactText.SetActive(false);
    }

    void ClosePuzzle()
    {
        puzzlePanel.SetActive(false);
        puzzleOpen = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
