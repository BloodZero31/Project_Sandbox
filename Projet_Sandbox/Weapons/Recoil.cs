using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    public Transform cameraTransform;  // Référence à la caméra du joueur
    public float recoilX = 2f;         // Recoil sur l'axe vertical (vers le haut)
    public float recoilY = 1f;         // Recoil sur l'axe horizontal (gauche/droite)
    public float recoilZ = 0.5f;       // Recoil sur l'axe avant/arrière (zoom arrière)
    public float recoilSpeed = 10f;    // Vitesse à laquelle le recoil se produit
    public float returnSpeed = 15f;    // Vitesse à laquelle la caméra revient à sa position initiale

    private Vector3 originalPosition;  // Position originale de la caméra
    private Vector3 currentRecoil;     // Valeur actuelle du recoil

    void Start()
    {
        // Sauvegarder la position initiale de la caméra
        originalPosition = cameraTransform.localPosition;
        currentRecoil = Vector3.zero;
    }

    void Update()
    {
        // Appliquer le recoil de l'arme lorsque le joueur tire
        if (Input.GetMouseButton(0))  // Tir continu en appuyant sur le clic gauche
        {
            ApplyRecoil();
        }

        // Retourner la caméra à sa position initiale après le tir
        RecoverRecoil();
    }

    // Méthode pour appliquer le recoil
    void ApplyRecoil()
    {
        // Générer une petite secousse en fonction des valeurs de recoil
        currentRecoil += new Vector3(
            Random.Range(-recoilY, recoilY),  // Légère secousse gauche/droite
            Random.Range(0, recoilX),         // Secousse vers le haut
            Random.Range(-recoilZ, 0)         // Légère secousse vers l'arrière
        );

        // Appliquer le déplacement de la caméra en fonction de la vitesse du recoil
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, originalPosition + currentRecoil, Time.deltaTime * recoilSpeed);
    }

    // Méthode pour retourner la caméra à sa position initiale après le recoil
    void RecoverRecoil()
    {
        // Réduire graduellement l'effet du recoil
        currentRecoil = Vector3.Lerp(currentRecoil, Vector3.zero, Time.deltaTime * returnSpeed);

        // Ramener la caméra à sa position originale
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, originalPosition, Time.deltaTime * returnSpeed);
    }
}
