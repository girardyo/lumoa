using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeInfo : MonoBehaviour
{
    protected int MaxLife;
    [HideInInspector]
    public int CurrentLife;

    [SerializeField]
    protected LifeScriptable LifeDataInfo;

    private void Start()
    {
        MaxLife = LifeDataInfo.MaxLife;
        CurrentLife = MaxLife;
    }



    public abstract void Death();

}
