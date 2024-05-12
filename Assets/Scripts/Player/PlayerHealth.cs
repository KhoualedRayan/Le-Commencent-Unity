using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    private bool isInvincible = false;
    //délai entre chaque clignotement lors de la prise de dégats
    public float invicibiltyFlashDelay = 0.15f;
    //temps d'invicibilité
    public float invicibilityTime = 1f;


    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public static PlayerHealth instance;
    public AudioClip hitSound;
    public AudioClip deathSound;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a déjà plus d'une instance de PlayerHealth dans la scène.");
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

    //Le perso prend des dégâts, puis est invicible pdt x secondes
    public void TakeDamage(int damage)
    {
        if(!isInvincible)
        {
            AudioManager.instance.PlayClipAt(hitSound,transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth); 
            //vérifie si le joueur est toujours vivant
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
        //Joue l'audio de mort
        AudioManager.instance.PlayClipAt(deathSound,transform.position);
        //Bloque les mouvements du perso
        PlayerMovement.instance.StopVelocity();

        PlayerMovement.instance.enabled = false;
        
        //Jouer l'animation d'élimination
        PlayerMovement.instance.animator.SetTrigger("Die");
        //Empêcher les interactions physique avec les autres éléments de la scène
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        //Lance le gameover
        GameOverManager.instance.OnPlayerDeath();
    }
    public void Respawn()
    {
        //Réactive les mouvements du perso
        PlayerMovement.instance.enabled = true;
        
        //Jouer l'animation de Respawn
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        //Recouvre les interactions physique avec les autres éléments de la scène
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        //Remet les pv au max
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    //Fonction Coroutine qui permet de gérer le clignotement du perso quand il est invincible
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
    public void SetCurrentHealth(int health)
    {
        this.currentHealth = health;
        healthBar.SetHealth(currentHealth);
    }
}
