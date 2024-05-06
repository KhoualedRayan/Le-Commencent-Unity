using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    private bool isInvincible = false;
    //d�lai entre chaque clignotement lors de la prise de d�gats
    public float invicibiltyFlashDelay = 0.15f;
    //temps d'invicibilit�
    public float invicibilityTime = 1f;


    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a d�j� plus d'une instance de PlayerHealth dans la sc�ne.");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) )
        {
            TakeDamage(55);
        }
    }

    //Heal les hp du perso
    public void HealPlayer(int healAmout)
    {
        currentHealth = Math.Min(maxHealth, healAmout + currentHealth);         
        healthBar.SetHealth(currentHealth);
    }

    //Le perso prend des d�g�ts, puis est invicible pdt x secondes
    public void TakeDamage(int damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth); 
            //v�rifie si le joueur est toujours vivant
            if(currentHealth <= 0)
            {
                Die();
                return;
            }          
            isInvincible = true;
            StartCoroutine(InvicibiltyFlash());
            StartCoroutine(HandleInvincibilityDelay()); 
        }
    }
    public void Die()
    {
        Debug.Log("Joueur mort");
        //Bloque les mouvements du perso
        PlayerMovement.instance.StopVelocity();

        PlayerMovement.instance.enabled = false;
        
        //Jouer l'animation d'�limination
        PlayerMovement.instance.animator.SetTrigger("Die") ;
        //Emp�cher les interactions physique avec les autres �l�ments de la sc�ne
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;

    }

    //Fonction Coroutine qui permet de g�rer le clignotement du perso quand il est invincible
    public IEnumerator InvicibiltyFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibiltyFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibiltyFlashDelay);
        }

    }
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTime);    
        isInvincible = false;

    }
    public int getCurrentHealth()
    {
        return currentHealth;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }
}
