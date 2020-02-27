using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnchantCount : MonoBehaviour
{
    private int count;
    public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        count = 5;
        // Invoke("Call", 10);
        countText.text = "Count : " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Le niveau d'enchantement est de " + count);
        count += 1;
        countText.text = "Count : " + count.ToString();
        if(count >= 1000)
        {
            countText.text = "Enchantement prêt ! ";
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            // Debug.Log("Perte de l'enchantement");
            count = 0;
            // countText.text = "Count : " + count.ToString();

        }
    }
}

