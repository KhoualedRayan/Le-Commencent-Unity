using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;

    public static Inventory instance;

    public Text coinsCountText;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a d�j� plus d'une instance de Inventory dans la sc�ne.");
            return;
        }
        instance = this;
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
}
