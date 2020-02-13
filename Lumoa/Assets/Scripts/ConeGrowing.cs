using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeGrowing : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    Vector3 newScale = new Vector3(26, 0, 26);
    private void OnTriggerEnter(Collider other)
    {
        if (enter && other.tag == "Player")
        {
            Debug.Log("Cone touched cubeTest");
        }
    }
    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        if (stay && other.tag == "Player")
        {
           /* if (stayCount > 1f)
            {*/
                Debug.Log("Cube staying in Cone");
                stayCount = stayCount - 3f;

                /*other.gameObject.GetComponent<NewBehaviourScript>().setLife(other.gameObject.GetComponent<NewBehaviourScript>().getLife() - 1);*/
                other.gameObject.GetComponent<Player>().setBool(true);
                /*Debug.Log(other.gameObject.GetComponent<NewBehaviourScript>().getLife());*/
                Debug.Log(other.gameObject.GetComponent<Player>().getBool());
/*            }
*/        /*    else
            {
                stayCount = stayCount + Time.deltaTime;
            }*/
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit && other.tag == "Player")
        {
            Debug.Log("Cube exiting Cone");
            other.gameObject.GetComponent<Player>().setBool(false);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Debug.Log(other.gameObject.GetComponent<Player>().getBool());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale = Vector3.Lerp(new Vector3(1,0,1), newScale, Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
      transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime);
        //transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 30 * Time.deltaTime);
        //transform.localScale += new Vector3(0.2f, 0, 0.2f);
    }

}
