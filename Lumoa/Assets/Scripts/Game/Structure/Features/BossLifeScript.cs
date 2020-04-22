using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeScript : LifeInfo
{
    public Animator animator;
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
        if (CurrentLife == 0)
            Death();
    }




    public override void Death()
    {
        Debug.Log("DEATH");
        BossMode.Instance.isDead = true;
        AnimManager.LaunchAnim(animator, "Death");
    }


}
