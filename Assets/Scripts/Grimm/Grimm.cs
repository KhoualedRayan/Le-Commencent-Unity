using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grimm : MonoBehaviour
{
    private Text interactUI;
    private Text boiteDeDialogue;
    private bool isInRange = false;
    private string[] messages;
    private List<string> messagesList;
    private int position = 0;
    private void Awake()
    {
        messagesList = new List<string>();  
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        boiteDeDialogue = GameObject.FindGameObjectWithTag("BoiteDeDialogue").GetComponent<Text>();
        AjouterDialogue();
    }
    private void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            interactUI.enabled = false;
            if (position < messagesList.Count)
            {
                //Bloque les mouvements du perso et fait jouer l'animation d'idle
                PlayerMovement.instance.animator.SetFloat("Speed", 0f);
                PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
                PlayerMovement.instance.StopVelocity();
                PlayerMovement.instance.enabled = false;
                boiteDeDialogue.text = messagesList[position];

                boiteDeDialogue.enabled = true;
                position++;
            }
            else
            {
                //Le dialogue est fini, on réactive les mouvements du joueur
                //On enlève la boite de dialogue
                boiteDeDialogue.enabled=false;
                //Destroy(gameObject);
                position = 0;

                PlayerMovement.instance.enabled = true;
                PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;

            }

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
            if (interactUI != null)
            {
                isInRange = false;  
                interactUI.enabled = false;
            }
                
        }
    }
    private void AjouterDialogue()
    {
        messagesList.Add("JE   VAIS   TE   CONFERER   UN   NOUVEAU   POUVOIR.");
        messagesList.Add("IL   TE   SERA   UTILE   DANS   TON   PERIPLE ! \n APPUIE   SUR   A   POUR   L'UTLISER.");
        messagesList.Add("PARS   MAINTENANT...");
    }
}
