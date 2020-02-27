using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float dash;
    public bool didDash;
    public float turnSpeed;
    private Rigidbody RB;
    public float lerpTime = 5;
    public float currentLerpTime = 0;
    public bool mooved = false;

    void Start()
    {
        RB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            RB.AddForce(-Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            RB.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            RB.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            RB.AddForce(-Vector3.forward * speed);
        }
        transform.rotation = Quaternion.LookRotation(RB.velocity);

        if (Input.GetKeyDown(KeyCode.R))
        {
            RB.AddForce(Vector3.forward * dash);
            Debug.Log("R");
        }


    }




}
