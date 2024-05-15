using UnityEngine.UI;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public Item[] itemsToSell;
    public string npcName;
    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !ShopManager.instance.isInDialogue)
        {
            ShopManager.instance.OpenShop(itemsToSell, npcName);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
        }
    }
}
