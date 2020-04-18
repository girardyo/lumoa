using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float lifeTime = 0f;
    public float lifeTimeMax = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
        //Quaternion.Euler(Vector3.up * 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime < lifeTimeMax)
        {
            lifeTime = lifeTime + Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

