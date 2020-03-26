using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{

    public Transform targetTransform;
    public float speed = 1;
    public float distanceMinToHit = 2;

    [SerializeField]
    private GameObject bigFlare;
    [SerializeField]
    private ParticleSystem smallFlare;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetTransform);
        Vector3 actualPos = transform.position;
        actualPos += transform.forward * speed * Time.deltaTime;
        transform.position = actualPos;

        if(Vector3.Distance(transform.position,targetTransform.position) < distanceMinToHit)
        {
            Destroy(gameObject,2);
            smallFlare.Stop();
            Destroy(bigFlare);
        }
    }
}
