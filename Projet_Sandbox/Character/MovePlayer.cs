using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //D�claration des variables
    public float moveSpeed = 5f; //Vitesse de d�placement
    public float jumpForce = 7f; //Hauteur de saut (Axe Y)
    public Transform groundCheck; //Ajout sph�re (d�clencheur)
    public LayerMask groundLayer; //Ajout masque de v�rification (=sol)

    private Rigidbody rb; //Ajout Cmposant Rigidbody
    private bool isGrounded; //Ajout boll�en (=sol)

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Association Composant Rigidbosy => rb
    }

    void Update()
    {
        // D�tection du sol
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        // Mouvement horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalInput + transform.forward * forwardInput;
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);

        // Sauter si le personnage est au sol et que la touche espace est press�e
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump(); //Appel fonction Jump
        }
    }

    //D�finition fonction Jump
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); //Pr�cision Vecteur (sur l'axe Y)
    }

    void OnDrawGizmosSelected()
    {
        // Afficher une sph�re dans la vue d'�diteur pour visualiser la zone de d�tection du sol
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(groundCheck.position, 0.1f);
        }
    }
}