using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float timerBlizzard = 0.0f;
    public float timerStala = 0.0f;
    public int nombrePlume = 3;
    public int anglePlume = 40;
    private GameObject joueur;
    public GameObject blizzard;
    public GameObject shadow;
    public GameObject plume;
    public GameObject coneGlace;
    private GameObject plumeInstance;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        if (joueur == null)
        {
            joueur = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(joueur.transform.position.x, transform.position.y, joueur.transform.position.z));
        AttaqueBlizzard();
        AttaqueStalagmite();
        if (Input.GetKey(KeyCode.X))
            AttaquePlume();
        if (Input.GetKey(KeyCode.C))
            AttaqueConeGlace();
    }

    void AttaqueBlizzard()
    {
        if (timerBlizzard < 10)
        {
            timerBlizzard = timerBlizzard + Time.deltaTime;
        }
        else
        {
            timerBlizzard = 0;
            do
            {
                pos = new Vector3(Random.Range(joueur.transform.position.x - 4f, joueur.transform.position.x + 4f), 0.077f, Random.Range(joueur.transform.position.z - 4f, joueur.transform.position.z + 4f));
            } while (Vector3.Distance(pos, joueur.transform.position) < 1.5f && Vector3.Distance(pos, transform.position) < 4f);
            Instantiate(blizzard, pos, Quaternion.identity);
        }
    }

    void AttaqueStalagmite()
    {
        if (timerStala < 1)
        {
            timerStala = timerStala + Time.deltaTime;
        }
        else
        {
            timerStala = 0;
            float x = Random.Range(-20.0f, 20.0f);
            float z = Random.Range(-20.0f, 20.0f);
            Instantiate(shadow, new Vector3(x, 0.077f, z), Quaternion.identity);
        }
    }

    void AttaquePlume()
    {
        var angleDegre = (anglePlume / (nombrePlume-1));
        var angleMinRotation = -angleDegre*((nombrePlume - 1)/2);

        for(int i = 0; i<nombrePlume; i++)
        {
            plumeInstance = Instantiate(plume, new Vector3(transform.position.x, 2f
                , transform.position.z), transform.rotation);
            plumeInstance.transform.rotation *= Quaternion.Euler(Vector3.up * (angleMinRotation + angleDegre * i));
            plumeInstance.GetComponent<Rigidbody>().AddForce(plumeInstance.transform.forward * 300);
        }
    }

    void AttaqueConeGlace()
    {
        Instantiate(coneGlace, new Vector3(transform.position.x, 0.078f, transform.position.z), transform.rotation);
    }
}
