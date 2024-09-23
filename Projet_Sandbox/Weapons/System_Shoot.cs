using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_Shoot : MonoBehaviour
{
    public int maxAmmo = 10;  // Nombre maximum de munitions
    private int currentAmmo;  // Nombre actuel de munitions
    private Animator anim;    // R�f�rence � l'Animator

    void Start()
    {
        // Initialisation de l'Animator et du nombre de munitions
        anim = GetComponent<Animator>();
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        // Si clic gauche et il reste des munitions
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            anim.SetTrigger("Shoot");
            currentAmmo--;  // Diminution des munitions
            Debug.Log("Tir effectu�. Munitions restantes : " + currentAmmo);
        }

        // Si appui sur la touche 'R' pour recharger
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Reload");
            currentAmmo = maxAmmo;  // Remise � la valeur maximale des munitions
            Debug.Log("Rechargement effectu�. Munitions : " + currentAmmo);
        }
    }
}