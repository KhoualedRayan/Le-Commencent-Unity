using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public int coinsToAdd;
    public Animator animator;
    public AudioClip clip;
    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") )
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled= false;
            isInRange = false;
        }
    }
    private void OpenChest()
    {
        //On joue le son de l'ouverture du coffre
        AudioManager.instance.PlayClipAt(clip,transform.position);
        //On rajoute des pièces
        Inventory.instance.AddCoins(coinsToAdd);
        //On désactive le coffre et le text
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
        //On joue l'animation du coffre
        animator.SetTrigger("OpenChest");
    }
}
