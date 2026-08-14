using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    public float interactDistance = 3f;
    public GameObject interactUI;
    public PickupView pickupView;


    void Start()
    {
        pickupView.OnClosed += HandlePickupClosed;
    }
    void Update()
    {
        if (pickupView.gameObject.activeSelf) return;

        interactUI.SetActive(false);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            InventoryItem item = hit.collider.GetComponentInParent<InventoryItem>();
            GlitchInteract glitch = hit.collider.GetComponentInParent<GlitchInteract>();
            GlitchCubeInteract glitchCube = hit.collider.GetComponentInParent<GlitchCubeInteract>();

            if (item != null || glitch != null || glitchCube != null)
            {
                interactUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (glitch != null)
                        glitch.Interact();

                    if (glitchCube != null)
                        glitchCube.Interact(GetComponentInChildren<AudioSource>());

                    if (item != null)
                    {
                        pickupView.ShowPickup(item);

                        InventoryManager inv = FindObjectOfType<InventoryManager>();
                        inv.AddItem(item);

                        item.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    void HandlePickupClosed(InventoryItem item)
    {
        
    }

}
