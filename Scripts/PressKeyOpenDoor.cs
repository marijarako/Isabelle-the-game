using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public AudioSource DoorOpenSound;
    public bool Action = false;
    public NumpadUI numpad;
    private Vector3 closedPos;
    private Quaternion closedRot;


    void Start()
    {
        Instruction.SetActive(false);
        closedPos = AnimeObject.transform.position;
        closedRot = AnimeObject.transform.rotation;

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                numpad.gameObject.SetActive(true);
            }
        }

    }
    public void OpenDoor()
    {
        Instruction.SetActive(false);
        AnimeObject.GetComponent<Animator>().Play("OpenDoor");
        ThisTrigger.SetActive(false);
        DoorOpenSound.Play();
        Action = false;
    }

    public void CloseDoor()
    {
        Animator anim = AnimeObject.GetComponent<Animator>();

        if (anim != null)
            anim.enabled = false;   

        AnimeObject.transform.position = closedPos;
        AnimeObject.transform.rotation = closedRot;
    }
}