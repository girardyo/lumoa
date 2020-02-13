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
    //currentLerpTime += Time.deltaTime
        //Vector3 result = Vector3.Lerp(a, b, currentLerpTime / lerpTime);

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Q))
        {
            //currentLerpTime += Time.deltaTime;
            //Vector3 result = Vector3.Lerp(a, b, currentLerpTime / lerpTime);
            //transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

            //transform.rotation()
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 270, transform.eulerAngles.z);
            //transform.position = Vector3.Lerp() ;
            RB.AddForce(Vector3.left * speed * Time.deltaTime);


        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90,transform.eulerAngles.z);
            RB.AddForce(Vector3.right * speed * Time.deltaTime );

        }

        if (Input.GetKey(KeyCode.Z))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0,transform.eulerAngles.z);
            RB.AddForce(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            RB.AddForce(-Vector3.forward * speed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            RB.AddForce(Vector3.forward * dash);
        }
    }
}
