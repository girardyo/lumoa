using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListAttack", menuName = "Data/ListScriptableAttack", order = 1)]

public class ListScriptableAttack : ScriptableObject
{
    public List<AttackScriptable> ListAttacks;
}
