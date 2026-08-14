using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CouchUnlock : MonoBehaviour
{
    private Collider couchCollider;

    void Awake()
    {
        couchCollider = GetComponent<Collider>();
        couchCollider.enabled = false; 
    }

    void Update()
    {
        if (GameFlags.ClockPuzzleSolved)
        {
            couchCollider.enabled = true; 
            enabled = false; 
        }
    }
}
