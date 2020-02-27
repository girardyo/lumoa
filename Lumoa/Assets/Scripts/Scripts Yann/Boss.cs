using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject ProjectileG;
    public GameObject ProjectileD;
    public GameObject ProjectileRage;
    public GameObject ProjectileGRage;
    public GameObject ProjectileDRage;
    public Transform Spawn;
    int Vie;

    //float FireRate = 1.0f;
   // float NextFire;

    // Start is called before the first frame update
    void Start()
    {
        Vie = 5; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o")) // && Time.time > NextFire)
        {
           // NextFire = Time.time + FireRate;
            GameObject a = Instantiate(Projectile, Spawn.position, Spawn.rotation);
            GameObject b = Instantiate(ProjectileG, Spawn.position, Spawn.rotation);
            GameObject c = Instantiate(ProjectileD, Spawn.position, Spawn.rotation);
            Destroy(a, 3f);
            Destroy(b, 3f);
            Destroy(c, 3f);
            Vie = 1;
           // Debug.Log("G TIRAY");
        }
        if (Vie <= 2)
        {
            Debug.Log("PAS KONTAN");
        }
    }
}
