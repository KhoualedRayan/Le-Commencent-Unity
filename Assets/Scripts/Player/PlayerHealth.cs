using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvincible = false;
    //délai entre chaque clignotement lors de la prise de dégats
    public float invicibiltyFlashDelay = 0.15f;
    //temps d'invicibilité
    public float invicibilityTime = 1f;


    public SpriteRenderer graphics;
    public HealthBar healthBar;
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
            TakeDamage(15);
        }
    }
    //Le perso prend des dégâts, puis est invicible pdt x secondes
    public void TakeDamage(int damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth); 
            isInvincible = true;
            StartCoroutine(InvicibiltyFlash());
            StartCoroutine(HandleInvincibilityDelay()); 
        }
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
}
