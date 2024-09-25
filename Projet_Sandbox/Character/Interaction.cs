using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public string interactableTag = "Interactable";  // Tag des objets interactifs
    private bool isInRange = false;                  // Indique si le joueur est proche de l'objet
    private GameObject currentInteractableObject;    // Référence à l'objet interactif actuel

    void Update()
    {
        // Si le joueur est dans la zone d'interaction et appuie sur la touche E
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    // Méthode pour gérer l'interaction
    void InteractWithObject()
    {
        if (currentInteractableObject != null)
        {
            // Exemple d'interaction : Désactiver l'objet pour simuler le ramassage
            Debug.Log("Interaction avec l'objet : " + currentInteractableObject.name);
            currentInteractableObject.SetActive(false);  // Désactiver l'objet
            isInRange = false;  // Sortir de l'état d'interaction
        }
    }

    // Lorsque le joueur entre dans la zone de trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(interactableTag))  // Vérifier si l'objet a le tag "Interactable"
        {
            Debug.Log("Joueur proche de l'objet : " + other.gameObject.name);
            isInRange = true;  // Le joueur est dans la zone d'interaction
            currentInteractableObject = other.gameObject;  // Sauvegarder l'objet interactif
        }
    }

    // Lorsque le joueur sort de la zone de trigger
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(interactableTag))  // Vérifier si l'objet a le tag "Interactable"
        {
            Debug.Log("Joueur éloigné de l'objet : " + other.gameObject.name);
            isInRange = false;  // Le joueur n'est plus dans la zone d'interaction
            currentInteractableObject = null;   // Supprimer la référence à l'objet interactif
        }
    }
}
