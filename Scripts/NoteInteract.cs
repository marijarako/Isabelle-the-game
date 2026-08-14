using UnityEngine;

public class NoteInteract : MonoBehaviour
{
    public GameObject interactText;
    public GameObject NotePanel;

    [Header("First time effects")]
    public AudioSource dingSound;
    public GameObject ball;          
    public Color ballActiveColor;
    
    public AudioSource audioSource;
    public AudioClip closeNoteSound;

    bool puzzleOpen = false;
    bool firstTimeClosed = false;

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
        NotePanel.SetActive(true);
        puzzleOpen = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        interactText.SetActive(false);
    }

    void ClosePuzzle()
    {
        NotePanel.SetActive(false);
        puzzleOpen = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        if (closeNoteSound != null)
            audioSource.PlayOneShot(closeNoteSound);


        if (!firstTimeClosed)
        {
            firstTimeClosed = true;
            FirstTimeEvent();
        }
    }

    void FirstTimeEvent()
    {
        
        if (dingSound != null)
            dingSound.Play();

        
        Renderer r = ball.GetComponent<Renderer>();
        if (r != null)
            r.material.color = ballActiveColor;

        
        Collider col = ball.GetComponent<Collider>();
        if (col != null)
            col.enabled = true;
        


    }
}
