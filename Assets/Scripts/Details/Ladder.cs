using UnityEngine;
using UnityEngine.UI;
public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topCollider;
    public Text interactUI;
    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && playerMovement.IsClimbing() && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.SetClimbing(false);
            topCollider.isTrigger = false;
            return;
        }
        if(isInRange && Input.GetKeyDown(KeyCode.E) ) { 
            playerMovement.SetClimbing(true);
            topCollider.isTrigger = true;
            //permet de mettre la position du personnage au centre de l'échelle en gardant son y et z
            playerMovement.transform.position = new Vector3(transform.position.x,playerMovement.transform.position.y,playerMovement.transform.position.z);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.SetClimbing(false);
            topCollider.isTrigger = false;
            if(interactUI!= null) 
                interactUI.enabled = false;
        }
    }
}
