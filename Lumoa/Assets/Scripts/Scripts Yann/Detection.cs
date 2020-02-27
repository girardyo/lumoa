using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject ProjectileG;
    public GameObject ProjectileD;
    public GameObject ProjectileRage;
    public GameObject ProjectileGRage;
    public GameObject ProjectileDRage;
    public Transform Spawn;
    float FireRate =1.0f;
    float NextFire;
    int Vie;

    void Start()
    {
        Vie = 5 ;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            GameObject.FindWithTag("Boss");
            GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("Touché");

            //GameObject a = Instantiate(Projectile, Spawn.position, Spawn.rotation);
            //GameObject b = Instantiate(ProjectileG, Spawn.position, Spawn.rotation);
            //GameObject c = Instantiate(ProjectileD, Spawn.position, Spawn.rotation);
           //Destroy(a, 3f);
           // Destroy(b, 3f);
           // Destroy(c, 3f);

        }
    }

    void OnTriggerStay(Collider other)
    {
        if(Time.time > NextFire)
        {
            if(Vie <= 3)
            {
                FireRate = 0.5f;
                NextFire = Time.time + FireRate;
                GameObject a1 = Instantiate(ProjectileRage, Spawn.position, Spawn.rotation);
                GameObject b1 = Instantiate(ProjectileGRage, Spawn.position, Spawn.rotation);
                GameObject c1 = Instantiate(ProjectileDRage, Spawn.position, Spawn.rotation);
                Destroy(a1, 3f);
                Destroy(b1, 3f);
                Destroy(c1, 3f);
            }
            if (Vie > 3)
            {
                NextFire = Time.time + FireRate;
                GameObject a = Instantiate(Projectile, Spawn.position, Spawn.rotation);
                GameObject b = Instantiate(ProjectileG, Spawn.position, Spawn.rotation);
                GameObject c = Instantiate(ProjectileD, Spawn.position, Spawn.rotation);
                Destroy(a, 3f);
                Destroy(b, 3f);
                Destroy(c, 3f);
                Debug.Log("G TIRAY");
            }
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = Color.white;
            Debug.Log("Sortie");
        }
    }

}