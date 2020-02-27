using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float timerAttaque = 0.0f;

    public float lifeTimeBlizzard = 0.0f;

    public float lifeTimeConeGlace = 0.0f;

    public float timerBetweenStala = 0.0f;
    public float StalaLifeTime = 0.0f;
    private bool StalaAttack = false;

    public int nombrePlume = 3;
    public int anglePlume = 40;

    private GameObject joueur;
    public GameObject blizzard;
    public GameObject shadow;
    public GameObject plume;
    public GameObject coneGlace;
    private GameObject plumeInstance;
    public GameObject laser;
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
        lifeTimeBlizzard = lifeTimeBlizzard + Time.deltaTime;
        lifeTimeConeGlace = lifeTimeConeGlace + Time.deltaTime;
        if (StalaAttack)
        {
            AttaqueStalagmite();
        }
        if (timerAttaque < 2f)
        {
            timerAttaque = timerAttaque + Time.deltaTime;
        }
        else
        {
            timerAttaque = 0;
            switch (Random.Range(1, 6))
            {
                case 1:
                    if (lifeTimeBlizzard >= 10f)
                    {
                        AttaqueBlizzard();
                        lifeTimeBlizzard = 0;
                        Debug.Log("Attaque 4");
                    }
                    else
                    {
                        AttaquePlume();
                    }
                    break;
                case 2:
                    if (!StalaAttack)
                    {
                        StalaAttack = true;
                        Debug.Log("Attaque 2");
                    } else {
                        AttaquePlume();
                    }
                    break;
                case 3:
                    AttaquePlume();
                    Debug.Log("Attaque 3");
                    break;
                case 4:
                    if (lifeTimeConeGlace >= 10f)
                    {
                        AttaqueConeGlace();
                        lifeTimeConeGlace = 0;
                        Debug.Log("Attaque 4");
                    } else {
                        AttaquePlume();
                    }
                    break;
                case 5:
                    AttaqueLaser();
                    Debug.Log("Attaque 5");
                    break;
            }
        }            
    }

    void AttaqueBlizzard()
    {
        do
        {
            pos = new Vector3(Random.Range(joueur.transform.position.x - 3f, joueur.transform.position.x + 3f), 0.077f, Random.Range(joueur.transform.position.z - 3f, joueur.transform.position.z + 3f));
        } while (Vector3.Distance(pos, joueur.transform.position) < 1f && Vector3.Distance(pos, transform.position) < 3f);
        Instantiate(blizzard, pos, Quaternion.identity);
    }

    void AttaqueStalagmite()
    {
        if (StalaLifeTime < 15)
        {
            StalaLifeTime = StalaLifeTime + Time.deltaTime;
            if (timerBetweenStala < 1)
            {
                timerBetweenStala = timerBetweenStala + Time.deltaTime;
            }
            else
            {
                timerBetweenStala = 0;
                float x = Random.Range(-20.0f, 20.0f);
                float z = Random.Range(-20.0f, 20.0f);
                Instantiate(shadow, new Vector3(x, 0.077f, z), Quaternion.identity);
            }
        }
        else
        {
            StalaLifeTime = 0;
            StalaAttack = false;
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
            plumeInstance.GetComponent<Rigidbody>().AddForce(plumeInstance.transform.forward * 500);
        }
    }

    void AttaqueConeGlace()
    {
        Instantiate(coneGlace, new Vector3(transform.position.x, 0.078f, transform.position.z), transform.rotation);
    }

    void AttaqueLaser()
    {
        Instantiate(laser, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
    }
}
