using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //Déclaration des variables
    public float moveSpeed = 5f; //Vitesse de déplacement
    public float jumpForce = 7f; //Hauteur de saut (Axe Y)
    public Transform groundCheck; //Ajout sphère (déclencheur)
    public LayerMask groundLayer; //Ajout masque de vérification (=sol)

    private Rigidbody rb; //Ajout Cmposant Rigidbody
    private bool isGrounded; //Ajout bolléen (=sol)

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Association Composant Rigidbosy => rb
    }

    void Update()
    {
        // Détection du sol
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        // Mouvement horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalInput + transform.forward * forwardInput;
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);

        // Sauter si le personnage est au sol et que la touche espace est pressée
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump(); //Appel fonction Jump
        }
    }

    //Définition fonction Jump
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); //Précision Vecteur (sur l'axe Y)
    }

    void OnDrawGizmosSelected()
    {
        // Afficher une sphère dans la vue d'éditeur pour visualiser la zone de détection du sol
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(groundCheck.position, 0.1f);
        }
    }
}