using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{

    #region Callable

    public static void LaunchAnim(Animator animator, string animName)
    {
        LaunchAnimOrchestration(animator, animName);
    }

    #endregion





    #region Orchestration

    private static void LaunchAnimOrchestration(Animator animator, string animName)
    {
        StartAnim(animator, animName);
    }

    #endregion





    #region Tools

    private static void StartAnim(Animator animator, string animName)
    {
        animator.Play(animName);
    }

    #endregion


}
