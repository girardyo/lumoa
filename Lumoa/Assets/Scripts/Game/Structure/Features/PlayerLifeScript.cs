using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeScript : LifeInfo
{
    private bool isPlayerDead=false;
    public RectTransform rectTransform;


    private void Start()
    {
        MaxLife = LifeDataInfo.MaxLife;
        CurrentLife = MaxLife;
        rectTransform.localScale = new Vector3((float)CurrentLife / 10f, 1f, 1f);
    }


    private void Update()
    {

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Damage")
        {
            if(CurrentLife >=1)
            {
                LifeManager.UpdateLife(-1, this);
            }
            Debug.Log("Current life" + CurrentLife);
            rectTransform.localScale = new Vector3((float)CurrentLife / 10f, 1f, 1f);

            if (CurrentLife == 0)
                Death();
        }
    }

    public override void Death()
    {
        Debug.Log("DEATH");
        isPlayerDead = true;
        Menu.IsGameEnded = true;
    }



    public bool getIsPlayerDead()
    {
        return isPlayerDead;
    }
}
