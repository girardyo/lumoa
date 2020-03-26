using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public static MonoBehaviour instance;

    private void Awake()
    {
        instance = this;
    }



    #region Callable

    public static void LaunchAttackCAC(BoxCollider Weapon, Animator animator, string animName, AudioSource audio)
    {
        LaunchAttackCACOrchestration(Weapon, animator, animName, audio);
    }

    public static void LaunchAttackDist(GameObject Proj, float Force, Transform Spawn, Animator animator, string animName, AudioSource audio)
    {
        LaunchAttackDistOrchestration(Proj, Force, Spawn, animator, animName, audio);
    }

    #endregion



    #region Orchestration

    private static void LaunchAttackCACOrchestration(BoxCollider weapon, Animator animator, string animName, AudioSource audio)
    {
        AnimManager.LaunchAnim(animator, animName);
        SoundManager.LaunchAudio(audio);

        ActivateColliderTools(weapon);
        instance.StartCoroutine(WaitforAnimtoEnd(animator));
        DeactivateColliderTools(weapon);
    }

    private static void LaunchAttackDistOrchestration(GameObject Proj, float Force, Transform Spawn, Animator animator, string animName, AudioSource audio)
    {
        AnimManager.LaunchAnim(animator, animName);

        SoundManager.LaunchAudio(audio);

        LaunchProj(Proj, Force, Spawn);

    }


    #endregion



    #region Tools

    private static void ActivateColliderTools(BoxCollider weapon)
    {
        weapon.enabled = true;
    }

    private static void DeactivateColliderTools(BoxCollider weapon)
    {
        weapon.enabled = false;
    }

    private static void LaunchProj(GameObject Proj, float Force, Transform Spawn)
    {
        Instantiate(Proj);
        Proj.transform.position = Spawn.position;
        Proj.GetComponent<Rigidbody>().AddForce(Vector3.forward*Force);
    }

    private static IEnumerator WaitforAnimtoEnd(Animator animator)
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }


    #endregion


}
