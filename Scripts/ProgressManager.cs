using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}