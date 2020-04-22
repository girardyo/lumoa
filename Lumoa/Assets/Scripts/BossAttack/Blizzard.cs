using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : MonoBehaviour
{
    public int sizeUpMaxXY = 600;
    public int sizeUpMaxZ = 300;
    public int lifeTimeMax = 10;
    private float smooth = 0.3f;
    private float lifeTime = 0.0f;
    private bool playerInside = false;
    private Vector3 tailleInitial;

    void Start()
    {
        tailleInitial = transform.localScale;
        if (BossMode.Instance.rageMode)
        {
            smooth = 1f;
        }
    }

    void Update()
    {
        Vector3 newScale = new Vector3(sizeUpMaxXY, sizeUpMaxXY, sizeUpMaxZ); // Les dimensions souhaités
        transform.localScale = Vector3.Lerp(tailleInitial, newScale, lifeTime*smooth);
        if (lifeTime < lifeTimeMax)
        {
            lifeTime = lifeTime + Time.deltaTime;
        }
        else
        {
            if (playerInside)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().setMoveSpeed(5.0f);
            }
            Destroy(gameObject);
        }
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().setMoveSpeed(2.0f);
            playerInside = true;
        }
    }

    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().setMoveSpeed(5.0f);
            playerInside = false;
        }
    }
}
