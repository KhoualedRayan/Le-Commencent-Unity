using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    //Fonction utilisé lors de l'initialisation du jeu qui met les hp de bases au max du perso
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    //fonction pour mettre à jour les pv du joueur
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); 
    }
}
