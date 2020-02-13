using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaserSpawn", 2,4);
        InvokeRepeating("LaserDespawn", 4,4);
    }

    // Update is called once per frame
    void Update()
    {
        //Le laser se déplace
            var a = GameObject.FindGameObjectWithTag("Laser").transform.rotation;
        Debug.Log(a);
        transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 30 * Time.deltaTime);
    }
    void LaserSpawn()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
    }
    void LaserDespawn()
        {
            GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
