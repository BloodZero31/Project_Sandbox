using SystemCollections;
using SystemCollections.Generic;
using UnityEngine;

public class SM_Character : MonoBehavior
{
	private Animator characterAnim;
	
	void Start()
	{
		characterAnim = GetComponent<Animator>();
	}
	
	
	void Update()
	{

		//Animations marche

		if (Input.GetKeyDown(KeyCode.Up))
		{
			characterAnim.SetTrigger("W_Forward");
		}
		
		if (Input.GetKeyDown(KeyCode.Down))
		{
			characterAnim.SetTrigger("W_Back");
		}
		
		if (Input.GetKeyDown(KeyCode.Left))
		{
			characterAnim.SetTrigger("W_Left");
		}
		
		if (Input.GetKeyDown(KeyCode.Right))
		{
			characterAnim.SetTrigger("W_Right");
		}

        //Animations course

        if (Input.GetKeyDown(KeyCode.Up) && Input.GetKeyDown(KeyCode.Shift))
        {
            characterAnim.SetTrigger("Run_Forward");
        }

		/*
        if (Input.GetKeyDown(KeyCode.Down) && Input.GetKeyDown(KeyCode.Shift))
        {
            characterAnim.SetTrigger("Run_Back");
        }
		*/

        if (Input.GetKeyDown(KeyCode.Left) && Input.GetKeyDown(KeyCode.Shift))
        {
            characterAnim.SetTrigger("Run_Left");
        }

        if (Input.GetKeyDown(KeyCode.Right) && Input.GetKeyDown(KeyCode.Shift))
        {
            characterAnim.SetTrigger("Run_Right");
        }
		

        //Animation "s'accroupir"

        if (Input.GetKeyDown(KeyCode.Right))
        {
            characterAnim.SetTrigger("Crouch");
        }

		//Animation Crouch --> Idle

		/*

        if (Input.GetKeyDown(KeyCode.Right))
        {
            characterAnim.SetTrigger("Crouch");
        }

		*/

    }

}