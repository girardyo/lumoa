using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Récupération du joueur à déterminer sur Unity
    public Transform targetPlayer;

    //Récupération du boss à déterminer sur Unity
    public Transform targetBoss;

    //"Vitesse" de déplacement de la caméra [0, 1]
    public float smoothSpeed;

    //Position de base de la caméra
    public Vector3 offset;

    public float border;

    private Vector3 cameraPos;
    private Vector3 smoothedCameraPos;

    private float distance;

    private void FixedUpdate()
    {
        distance = Vector3.Distance(targetPlayer.position, new Vector3(0, 0, 0));

        if (distance > border)
        {
            /*
            radian = Mathf.Atan2(targetPlayer.position.z - targetBoss.position.z, targetPlayer.position.x - targetBoss.position.x);
            print(Mathf.Cos(radian));
            print(Mathf.Sin(radian));
            cameraPos = offset + Vector3.up * (distance - border) + Vector3.Scale(Vector3.up, Vector3.Lerp(targetBoss.position, targetPlayer.position, Mathf.Sin(radian) < 0 ? Mathf.Sin(radian) : Mathf.Sin(radian) * -1));
            */
            cameraPos = offset + Vector3.back * offset.z * distance / border * -1 + Vector3.up * (distance - border) + Vector3.Lerp(targetBoss.position, targetPlayer.position, 0.5f);
        }
        else
        {
            cameraPos = offset + Vector3.back * offset.z * distance / border * -1 + Vector3.Lerp(targetBoss.position, targetPlayer.position, 0.5f);
        }

        smoothedCameraPos = Vector3.Lerp(transform.position, cameraPos, smoothSpeed);
        transform.position = smoothedCameraPos;

    }

}