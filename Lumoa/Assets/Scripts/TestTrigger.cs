using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (enter && other.name == "CubeTest")
        {
            Debug.Log("entered");
        }
    }

    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        if (stay && other.name=="CubeTest")
        {
            if (stayCount > 3f)
            {
                Debug.Log("staying");
                stayCount = stayCount - 3f;

                other.gameObject.GetComponent<NewBehaviourScript>().setLife(other.gameObject.GetComponent<NewBehaviourScript>().getLife()-1);
                Debug.Log(other.gameObject.GetComponent<NewBehaviourScript>().getLife());
            }
            else
            {
                stayCount = stayCount + Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit && other.name == "CubeTest")
        {
            Debug.Log("exit");
        }
    }
}
