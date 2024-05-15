using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public bool isInDialogue = false;

    public Animator animator;
    public Text npcNameText;

    public GameObject sellButtonPrefab;
    public Transform sellButtonsParent;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a déjà plus d'une instance de ShopManager dans la scène.");
            return;
        }
        instance = this;
    }
    void Update()
    {
        if (isInDialogue && Input.GetKeyDown(KeyCode.E))
        {
            CloseShop();
        }
    }
    public void OpenShop(Item[] items, string npcName)
    {
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.animator.SetFloat("Speed", 0f);
        npcNameText.text = npcName;
        UpdateItemsToSell(items);
        animator.SetBool("isOpen",true);
        StartCoroutine(WaitBeforeOpeningShop());
    }

    public void CloseShop()
    {
        animator.SetBool("isOpen", false);
        //On recouvre les mouvements du joueur
        PlayerMovement.instance.enabled = true;
        StartCoroutine(WaitBeforeClosingShop());
    }
    private IEnumerator WaitBeforeClosingShop()
    {
        yield return new WaitForSeconds(0.1f);
        isInDialogue = false;
    }    
    private IEnumerator WaitBeforeOpeningShop()
    {
        yield return new WaitForSeconds(0.1f);
        isInDialogue = true;
    }
    private void UpdateItemsToSell(Item[] items)
    {
        //Supprime les potentiels boutons présent dans le parent
        for( int i = 0; i < sellButtonsParent.childCount; i++ )
        {
            Destroy(sellButtonsParent.GetChild(i).gameObject);
        }
        //Instancie un bouton pour chaque item à vendre et le configure
        foreach (Item item in items) {
            GameObject button =  Instantiate(sellButtonPrefab,sellButtonsParent);
            SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
            buttonScript.itemName.text = item.itemName;
            buttonScript.itemImage.sprite = item.image;
            buttonScript.itemPrice.text = item.price.ToString();
            buttonScript.item = item;

            //Attacher un OnClick() au bouton
            //Attache la méthode BuyItem au bouton
            button.GetComponent<Button>().onClick.AddListener(delegate { buttonScript.BuyItem(); });
        }
    }
}
