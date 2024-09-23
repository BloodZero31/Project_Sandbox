using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;  // Vie maximale
    public int maxShield = 50;   // Bouclier maximal
    private int currentHealth;   // Vie actuelle
    private int currentShield;   // Bouclier actuel
    private bool isDead = false; // Flag pour la mort du personnage

    void Start()
    {
        currentHealth = maxHealth;  // Initialiser la vie à son maximum
        currentShield = maxShield;  // Initialiser le bouclier à son maximum
    }

    // Fonction pour recevoir des dégâts
    public void TakeDamage(int damage)
    {
        if (isDead) return;  // Si déjà mort, ne pas appliquer de dégâts

        if (currentShield > 0)
        {
            // Si le bouclier est actif, il absorbe les dégâts en premier
            int damageToShield = Mathf.Min(damage, currentShield); // Absorber les dégâts jusqu'à ce que le bouclier soit épuisé
            currentShield -= damageToShield;
            damage -= damageToShield;
        }

        if (damage > 0)
        {
            // Si des dégâts restent après la réduction du bouclier, affecter la vie
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();  // Appeler la fonction de mort si la vie est à 0
            }
        }

        Debug.Log("Vie restante : " + currentHealth + " | Bouclier restant : " + currentShield);
    }

    // Fonction de mort
    void Die()
    {
        isDead = true;
        Debug.Log("Le personnage est mort !");
        // Ici tu peux ajouter une animation de mort ou d'autres comportements
    }

    // Fonction de soin (optionnelle)
    public void Heal(int amount)
    {
        if (!isDead)
        {
            currentHealth = Mathf.Min(currentHealth + amount, maxHealth);  // Soigner sans dépasser la vie maximale
            Debug.Log("Soigné ! Vie actuelle : " + currentHealth);
        }
    }

    // Fonction pour recharger le bouclier (optionnelle)
    public void RechargeShield(int amount)
    {
        if (!isDead)
        {
            currentShield = Mathf.Min(currentShield + amount, maxShield);  // Recharger le bouclier sans dépasser le maximum
            Debug.Log("Bouclier rechargé ! Bouclier actuel : " + currentShield);
        }
    }
}
