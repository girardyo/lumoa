using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    int Vie;
    // Start is called before the first frame update
    void Start()
    {
        Vie = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vie <= 2)
        {
            Debug.Log("Le boss est pas content, il devrait passer en mode rage");
        }
    }
}
