using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;
    public Item item;
    public AudioClip clip;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            PickItem();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
    private void PickItem()
    {
        //On joue le son de la récupération de l'item
        AudioManager.instance.PlayClipAt(clip, transform.position);
        //On rajoute l'item dans l'inventaire
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        //On enlève le coffre de la scène
        interactUI.enabled = false;
        Destroy(gameObject);

    }
}
