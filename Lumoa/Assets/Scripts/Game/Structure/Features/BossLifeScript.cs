using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeScript : LifeInfo
{
    private bool isPlayerDead = false;

    public GameObject crack1; 
    public GameObject crack2;

    private void Start()
    {
        MaxLife = LifeDataInfo.MaxLife;
        CurrentLife = MaxLife;

        //rect.localScale = new Vector3((float)CurrentLife / 10f, 1f, 1f);

    }


    private void Update()
    {
        if (CurrentLife == 2)
            crack1.SetActive(true);

        if (CurrentLife == 1)
        {
            crack2.SetActive(true);
            BossMode.Instance.rageMode = true;
        }
    }




    public override void Death()
    {
        Debug.Log("DEATH");
        isPlayerDead = true;
    }



    public bool getIsPlayerDead()
    {
        return isPlayerDead;
    }
}
