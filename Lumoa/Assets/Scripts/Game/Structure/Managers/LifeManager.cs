using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{

    #region Callable

    public static void UpdateLife(int amount, LifeInfo lifeinfo)
    {
        UpdateCurrentLifeOrchestration(amount, lifeinfo);
    }
    #endregion



    #region Orchestration

    private static void UpdateCurrentLifeOrchestration(int amount, LifeInfo lifeinfo)
    {
        UpdateCurrentLife(amount, lifeinfo);
        VerificationDeath(lifeinfo);
    }

    #endregion


    #region Tools

    private static void UpdateCurrentLife(int amount, LifeInfo lifeinfo)
    {
        lifeinfo.CurrentLife += amount;
    }

    private static void VerificationDeath(LifeInfo lifeinfo)
    {
        if (lifeinfo.CurrentLife <= 0)
            lifeinfo.Death();
    }

    #endregion
}
