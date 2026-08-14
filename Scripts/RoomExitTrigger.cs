using UnityEngine;

public class RoomExitTrigger : MonoBehaviour
{
    public ScreenTransition transition;
    public PressKeyOpenDoor door;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            if (door != null)
                door.CloseDoor();

            transition.PlayTransition();
        }
    }
}
