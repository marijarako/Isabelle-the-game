using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PickupView : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text itemText;
    private InventoryItem currentItem;
    private InventoryManager inventory;
    private bool isPickupMode;
    public AudioSource openVoice;
    
    public AudioClip phoneOpenSound;
    public System.Action<InventoryItem> OnClosed;
    public AudioClip couchOpenSound;
    public AudioClip suitcaseOpenSound;

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
    }

    public void ShowPickup(InventoryItem item)
    {
        currentItem = item;
        isPickupMode = true;

        if (item.isCouch)
            GameFlags.CouchInteracted = true;

        itemImage.sprite = item.icon;
        itemText.text = item.itemName + "\n\n" + item.description;

        gameObject.SetActive(true);
        Time.timeScale = 0f;

        if (item.inspectVoice != null)
            openVoice.PlayOneShot(item.inspectVoice);

        if (item.isPhone && phoneOpenSound != null)
            openVoice.PlayOneShot(phoneOpenSound);
        else if (item.isCouch && couchOpenSound != null)
            openVoice.PlayOneShot(couchOpenSound);
        else if (item.isSuitcase && suitcaseOpenSound != null)
            openVoice.PlayOneShot(suitcaseOpenSound);
        else if (openVoice != null)
            openVoice.Play();
    }

    public void ShowInspect(InventoryItem item)
    {
        currentItem = item;
        isPickupMode = false;

        itemImage.sprite = item.icon;
        itemText.text = item.itemName + "\n\n" + item.description;

        gameObject.SetActive(true);

        //if (item.isPhone && phoneOpenSound != null)
        //    openVoice.PlayOneShot(phoneOpenSound);
        //else if (item.isCouch && couchOpenSound != null)
        //    openVoice.PlayOneShot(couchOpenSound);

    }
    public void Hide()
    {
        InventoryItem closedItem = currentItem;

        currentItem = null;

        if (closedItem != null && closedItem.afterCloseVoice != null)
            openVoice.PlayOneShot(closedItem.afterCloseVoice);

        Time.timeScale = 1f;
        StartCoroutine(DisableAfterCloseSound());

    }

    IEnumerator DisableAfterCloseSound()
    {
        yield return new WaitForSecondsRealtime(1f);
        gameObject.SetActive(false);
    }


}
