using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_Shoot : MonoBehavior
{

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        int ammo = X // avec X = Nombre max de munitions

        if (Input.GetKeyDown(KeyCode./* Clic Gauche */))
        {
            anim.SetTrigger("Shoot");
            ammo--;
        }

        if (Input.GetKeyDown(KeyCode./* Clic Gauche */))
        {
            anim.SetTrigger("Reload");

            
            for (int i = ammo; i <= X) // avec X = Nombre max de munitions
            {
                i++;
            }
            
        }
    }