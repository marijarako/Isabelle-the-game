using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public GameObject panel;
    public Image icon;
    private InventoryItem item;

    public bool IsEmpty => item == null;

    public void SetItem(InventoryItem newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;
        icon.enabled = true;
    }

    public void Clear()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
    public void Show()
    {
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
