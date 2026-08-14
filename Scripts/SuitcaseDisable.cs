using UnityEngine;

public class SuitcaseDisable : MonoBehaviour
{
   

    void Update()
    {
        if (GameFlags.CouchInteracted)
        {
            gameObject.SetActive(false); 
        }
    }
}
