using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTuto : MonoBehaviour
{
    //Récupération du joueur à déterminer sur Unity
    public Transform targetPlayer;



    //"Vitesse" de déplacement de la caméra [0, 1]
    public float smoothSpeed;

    //Position de base de la caméra
    public Vector3 offset;


    private Vector3 cameraPos;
    private Vector3 smoothedCameraPos;

    private float distance;

    private void FixedUpdate()
    {
        cameraPos = targetPlayer.position + offset;
       

        smoothedCameraPos = Vector3.Lerp(transform.position, cameraPos, smoothSpeed);
        transform.position = smoothedCameraPos;

    }

}