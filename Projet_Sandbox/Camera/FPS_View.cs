using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_View : MonoBehaviour
{
    //Déclaration des varibales
    public float mouseSensitivity = 100f; // Sensibilité de la souris
    public Transform playerBody; //Transformation composant Rigidbody
    private float xRotation = 0f; //Rotation sur l'axe X

    private Vector3 offset = new Vector3(0, 0, 0); //Offset

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Blocage du curseur de la souris au millieu de l'écran
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //Mouvement de la souris sur l'axe X
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //Mouvement de la souris sur l'axe Y

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        transform.position = playerBody.position + offset;
    }
}