﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagmite : MonoBehaviour
{
    public int moveSpeed = 50;
    private float lifeTime = 0f;
    public float lifeTimeMax = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime*moveSpeed);
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
