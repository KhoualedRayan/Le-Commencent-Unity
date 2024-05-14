using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;
    public Animator animator;
    
    public static DialogueManager instance;
    public bool isInDialogue = false;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a déjà plus d'une instance de DialogueManager dans la scène.");
            return;
        }
        instance = this;
        sentences = new Queue<string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInDialogue && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        
        //On bloque les mouvements du joueur
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.animator.SetFloat("Speed",0f);
        //On lance le dialogue
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.senteces)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    private void EndDialogue()
    {
        isInDialogue = false;
        animator.SetBool("isOpen",false);
        //On recouvre les mouvements du joueur
        PlayerMovement.instance.enabled = true;
    }
    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        isInDialogue = true;
    }
}
