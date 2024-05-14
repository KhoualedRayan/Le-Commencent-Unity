using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound,transform.position);
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.AddCoinInScene(1); 
            Destroy(gameObject);  
        }
    }
}
