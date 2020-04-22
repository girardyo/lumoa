using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintFinal : MonoBehaviour
{
    float Pourcent;   // var countdown
    public Text vieText; // affiche countdown
    public Text stateText; // affiche nbre d'input 
    public float NoteReussi; 
    public float Pourcentage2; // calculateur 
    public float NoteTotal; // max sur sprint
    private int Vie; 
    // Start is called before the first frame update
    void Start()
    {
        NoteReussi = 0f;
        Vie = 5;
        NoteTotal = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vie == 1)
        {
            Debug.Log("Sprint final");
            if (Pourcent < 500) 
            {
                Pourcent += Time.deltaTime;
            }
            vieText.text = " % :" + Pourcent.ToString(); 
            if (Input.GetKeyDown("p"))
            {
                if (Pourcent < 10)
                {
                    NoteReussiIncrement();

                }
            }
            if (Input.GetKeyDown("i"))
            {
                if (Pourcent < 10)
                {

                }
            }

            if (Pourcent >= 10)
            {
                Pourcentage2 = NoteReussi * 100f / NoteTotal;
                stateText.text = "Cap : " + Pourcentage2.ToString();
                if (Pourcentage2 <= 80)
                {
                    Debug.Log("Sprint final échoué, reprise du mode normal.");
                    Vie = 5;
                    Pourcentage2 = 0;
                    Pourcent = 0;
                }
                if (Pourcentage2 > 80)
                {
                    Debug.Log("Sprint final réussi");
                    Vie = 0;
                }
            }
        }
        if (Vie == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void NoteReussiIncrement()
    {
        NoteReussi += 1f;
    }


}
