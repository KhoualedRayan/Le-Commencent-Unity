using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public int id; // id de l'item
    public string itemName; // Nom de l'item
    public string description; // Description de l'item
    public Sprite image; // Image de l'item
    public int hpGiven; // Les HP rendus par l'item
    public int speedGiven; // La vitesse bonus donnée par l'item
    public float speedDuration; // La durée du buff de l'item
    public int price; // Prix de l'item

}
