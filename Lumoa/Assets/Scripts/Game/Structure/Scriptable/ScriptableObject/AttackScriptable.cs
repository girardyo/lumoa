using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Data/AttackScriptable", order = 2)]

public class AttackScriptable : ScriptableObject
{
    public int Damage;
    public int Force;

    public bool Distance;

    public GameObject Projectil;
    public BoxCollider Weapon;

    public Animation Anim;

    public AudioSource sound;

    public Transform spawn;
}


