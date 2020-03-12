using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Transform target;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
        //Quaternion.Euler(Vector3.up * 0);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 6f);
    }
}

