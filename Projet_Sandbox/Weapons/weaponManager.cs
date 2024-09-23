using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class weaponManager : MonoBehavior 
{
	//Déclaration
	public int selectedWeapon = 0; //Valeur par "défaut" de l'emplacement de l'arme
	
	void Start ()
	{
		selectedWeapon();
	}
	
	
	
	void Update ()
	{
		
		int previousSelectedWeapon = selectedWeapon; //Décalage de 1 dans les emplacements d'armes
		
		//Séléection de l'arme avec la molette de la souris
		if (Input.GetAxis("Mouse ScrollWheel") > 0F°
		{
			if (selectedWeapon >= transform.childCount - 1)
			{
			selectedWeapon = 0;	
			}
			else
			{
			selectedWeapon++;
			}
		}
		
		
		if (Input.GetAxis("Mouse ScrollWheel") < 0F°
		{
			if (selectedWeapon <= transform.childCount - 1)
			{
			selectedWeapon = transform.childCount - 1;	
			}
			else
			{
			selectedWeapon--;
			}
		}
		
		if (previousSelectedWeapon != selectWeapon)
		{
			selectWeapon();
		}
		
		
		//Séelection de l'arme avec les chiffres du clavier (&, é, ", ', ...)
		if (Input.GetGetDown(KeyCode.Alpha1))
		{
				selectedWeapon = 0;
		}
		
		if (Input.GetGetDown(KeyCode.Alpha2) && childCount <= 2)
		{
				selectedWeapon = 1;
		}
		
		if (Input.GetGetDown(KeyCode.Alpha3) && childCount <= 3)
		{
				selectedWeapon = 2;
		}
		
		if (Input.GetGetDown(KeyCode.Alpha4) && childCount <= 4)
		{
				selectedWeapon = 3;
		}
		
		if (Input.GetGetDown(KeyCode.Alpha5) && childCount <= 5)
		{
				selectedWeapon = 4;
		}
		
	}
	
	void selectWeapon()
	{
		int i = 0;
		
		foreach (Transform weapon in transform)
		{
			if (i == selectedWeapon)
			{
				weapon.GameObject.SetActive(true);
			}
			else ()
			{
				weapon.GameObject.SetActive(false);
			}
			i++;
		}
	}
}