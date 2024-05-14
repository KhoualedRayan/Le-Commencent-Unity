using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;

    public static Inventory instance;
    public int contentCurrentIndex = 0;
    public List<Item> content = new List<Item>();
    public Text coinsCountText;
    public Image itemImageUI;
    public Text itemNameUI;
    public Sprite emptyItemImage;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a déjà plus d'une instance de Inventory dans la scène.");
            return;
        }
        instance = this;
    }
    private void Start()
    {
        UpdateInventoryUI();
    }
    public void AddCoins(int coins)
    {
        this.coinsCount += coins;
        UpdateTextUI();
    }
    public void RemoveCoins(int coins) {
        this.coinsCount -= coins;
        UpdateTextUI();
    }
    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }
    public void ConsumeItem()
    {
        if(content.Count>0)
        {
            Item currentItem = content[contentCurrentIndex];
            PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
            PlayerMovement.instance.moveSpeed += currentItem.speedGiven;
            content.Remove(currentItem);    
            GetNextItem();
        }
        UpdateInventoryUI();
        
    }
    public void GetNextItem()
    {
        if (content.Count > 0) { 
            contentCurrentIndex++;
            if(contentCurrentIndex > content.Count - 1)
            {
                contentCurrentIndex = 0;
            }
            UpdateInventoryUI();
        }
    }
    public void GetPreviousItem()
    {
        if (content.Count > 0)
        {
            contentCurrentIndex = (contentCurrentIndex - 1 + content.Count) % content.Count;
            UpdateInventoryUI();
        }
    }
    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;    
        }
        else
        {
            itemImageUI .sprite = emptyItemImage;
            itemNameUI.text = "";
        }
    }
}
