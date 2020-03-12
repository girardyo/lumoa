using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeGrowing : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    Vector3 newScale = new Vector3(26, 0, 26);
    public float lifeTime = 0.0f;
    private bool playerInside = false;
    private void OnTriggerEnter(Collider other)
    {
        if (enter && other.tag == "Player")
        {
            playerInside = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (stay && other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().setBool(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit && other.tag == "Player")
        {
            Debug.Log("Cube exiting Cone");
            playerInside = false;
            other.gameObject.GetComponent<Player>().setBool(false);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime);
        if (lifeTime > 10f)
        {
            if (playerInside)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().setBool(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            Destroy(gameObject);
        }
        else
        {
            lifeTime = lifeTime + Time.deltaTime;
        }
    }
}
