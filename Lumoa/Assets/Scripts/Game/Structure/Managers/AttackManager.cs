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


    //TODO
    //Instance avec gameobject / position/  rotation
    //Instance avec gameobject / position / rotation / force


    #region Callable

    public static void LaunchAttackCAC(BoxCollider Weapon, Animator animator, string animName, AudioSource audio)
    {
        LaunchAttackCACOrchestration(Weapon, animator, animName, audio);
    }

    public static void LaunchAttackDist(GameObject Proj, float Force, Transform Spawn, Animator animator, string animName, AudioSource audio)
    {
        LaunchAttackDistOrchestration(Proj, Force, Spawn, animator, animName, audio);
    }

    public static void LaunchAttackObj(GameObject Proj, Transform Spawn, Animator animator, string animName, AudioSource audio)
    {
        LaunchAttackObjtOrchestration(Proj, Spawn, animator, animName, audio);
    }


    public static void LaunchAttackObjWithoutAnim(GameObject Proj, Vector3 Spawn, AudioSource audio)
    {
        LaunchAttackObjtOrchestrationWithoutAnim(Proj, Spawn, audio);
    }


    public static void LaunchAttackDistRota(GameObject Proj, float Force, Transform Spawn, Quaternion Rota, Animator animator, string animName, AudioSource audio)
    {
        LaunchAttackDistRotaOrchestration(Proj, Force, Spawn, Rota, animator, animName, audio);
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

    private static void LaunchAttackDistOrchestration(GameObject Proj, float Force, Vector3 Spawn, Animator animator, string animName, AudioSource audio)
    {
        AnimManager.LaunchAnim(animator, animName);

        SoundManager.LaunchAudio(audio);

        LaunchProjForce(Proj, Force, Spawn);

    }

    private static void LaunchAttackObjtOrchestration(GameObject Proj, Vector3 Spawn, Animator animator, string animName, AudioSource audio)
    {
        AnimManager.LaunchAnim(animator, animName);

        SoundManager.LaunchAudio(audio);

        LaunchProj(Proj, Spawn);

    }

    private static void LaunchAttackObjtOrchestrationWithoutAnim(GameObject Proj, Vector3 Spawn, AudioSource audio)
    {

        SoundManager.LaunchAudio(audio);

        LaunchProj(Proj, Spawn);

    }

    private static void LaunchAttackDistRotaOrchestration(GameObject Proj, float Force, Vector3 Spawn, Quaternion Rota, Animator animator, string animName, AudioSource audio)
    {
        AnimManager.LaunchAnim(animator, animName);

        SoundManager.LaunchAudio(audio);

        LaunchProjRota(Proj, Force, Spawn, Rota);

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

    private static void LaunchProjForce(GameObject Proj, float Force, Vector3 Spawn)
    {
        Instantiate(Proj);
        Proj.transform.position = Spawn;
        Proj.GetComponent<Rigidbody>().AddForce(Vector3.forward*Force);
    }

    private static void LaunchProj(GameObject Proj, Vector3 Spawn)
    {
        Instantiate(Proj);
        Proj.transform.position = Spawn;
    }

    private static void LaunchProjRota(GameObject Proj, float Force, Vector3 Spawn, Quaternion Rota)
    {
        Instantiate(Proj);
        Proj.transform.position = Spawn;
        Proj.transform.rotation = Rota;
        Proj.GetComponent<Rigidbody>().AddForce(Vector3.forward * Force);
    }

    private static IEnumerator WaitforAnimtoEnd(Animator animator)
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }


    #endregion


}
//TODO
//Instance avec gameobject / position/  rotation
//Instance avec gameobject / position / rotation / force
