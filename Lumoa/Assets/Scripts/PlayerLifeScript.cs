using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeScript : LifeScript
{
    public Slider LifeBar;
    private bool isPlayerDead = false;
    public Canvas canvas;

    public override void Death()
    {
        Debug.Log("DEATH");
        isPlayerDead = true;
//        canvas.enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        End();
    }

    public override void End()
    {
        Menu.IsGameEnded = true;
    }

    public override void UpdateLife(int nb)
    {
        base.UpdateLife(nb);
//        LifeBar.value = (float) CurrentLife / MaxLife;

    }

    public bool IsPlayerDead
    {
        get { return isPlayerDead; }
        set { isPlayerDead = value; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            UpdateLife(-1);
        }
    }
}
    