using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGRage : MonoBehaviour
{
    Transform target;
    public GameObject aksu;
    public Transform myTransform;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        transform.rotation *= Quaternion.Euler(Vector3.up * -5);



    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }
}

