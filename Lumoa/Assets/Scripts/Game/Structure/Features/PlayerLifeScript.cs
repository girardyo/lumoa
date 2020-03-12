using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeScript : LifeInfo
{
    private bool isPlayerDead=false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            LifeManager.UpdateLife(-50, this);
            Debug.Log("Current life" + CurrentLife);
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
