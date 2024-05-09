using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healthPoint = 40;
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) 
        {
            if(PlayerHealth.instance.getCurrentHealth() != PlayerHealth.instance.getMaxHealth())
            {
                AudioManager.instance.PlayClipAt(clip, transform.position);
                PlayerHealth.instance.HealPlayer(healthPoint);
                Destroy(gameObject);
            }

        }
    }
}
