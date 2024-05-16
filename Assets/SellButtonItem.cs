using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;

    public Item item;
    public AudioClip soundToPlay;
    public void BuyItem()
    {
        Debug.Log("Item achet� : " + itemName.text);
        //Si le joueur a assez de pi�ces
        if (Inventory.instance.coinsCount >= item.price)
        {
            //Rajoute l'item et lui enl�ve les pi�ces
            Inventory inventory = Inventory.instance;
            inventory.content.Add(item);
            inventory.RemoveCoins(item.price);
            //Update son text et ses items
            inventory.UpdateInventoryUI();
            inventory.UpdateTextUI();
            AudioManager.instance.PlayClipAt(soundToPlay,transform.position);
        }
    }
}
