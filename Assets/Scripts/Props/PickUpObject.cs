using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.AddCoinInScene(1); 
            Destroy(gameObject);  
        }
    }
}
