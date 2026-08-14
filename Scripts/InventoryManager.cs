using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Image[] slots;
    private InventoryItem[] items = new InventoryItem[5];
    private int selectedIndex = -1;
    public PickupView pickupView;


    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                ToggleSelect(i);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pickupView.gameObject.activeSelf)
            {
                pickupView.Hide();
                selectedIndex = -1;
                HighlightNone();
            }
        }


    }

    void ToggleSelect(int index)
    {
        if (selectedIndex == index)
        {
            selectedIndex = -1;
            HighlightNone();
            pickupView.Hide();
            return;
        }

        selectedIndex = index;
        HighlightSelected(index);

        InventoryItem item = items[index];
        if (item != null)
            pickupView.ShowInspect(item);
        else
            pickupView.Hide();
    }

    void HighlightSelected(int index)
    {
        HighlightNone();
        slots[index].color = Color.white;
    }

    void HighlightNone()
    {
        foreach (var slot in slots)
            slot.color = Color.gray;
    }

    public bool AddItem(InventoryItem item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                slots[i].sprite = item.icon;
                slots[i].enabled = true;
                return true;
            }
        }
        return false;
    }

    public InventoryItem GetSelectedItem()
    {
        if (selectedIndex < 0) return null;
        return items[selectedIndex];
    }
}
