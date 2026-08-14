using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    public Sprite icon;
    [TextArea] public string description;
    public bool isPhone;
    public bool isCouch;
    public bool isSuitcase;
    public AudioClip inspectVoice;
    public AudioClip afterCloseVoice;
}
