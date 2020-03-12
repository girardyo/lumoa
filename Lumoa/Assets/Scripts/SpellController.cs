using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellController : MonoBehaviour
{
    public GameObject SpellPrefab;
    public Transform Source;
    public Transform Target;
    public Vector3 offset;
    public float speed;

    public static List<GameObject> listSpells = new List<GameObject>();
    public static bool IsSpellReady = true;


    // Use this for initialization
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {   
        //rigibody.velocity = direction * speed;
        if (Input.GetKeyDown(KeyCode.R) && IsSpellReady)
        {
            CreateSpell(Source.position, Target.position);
            IsSpellReady = false;
        }

        DoActionSpells();
    }

    void DoActionSpells()
    {
        for (int i = 0; i < listSpells.Count; i++)
        {
            listSpells[i].GetComponent<SpellScript>().Rigibody.velocity = listSpells[i].GetComponent<SpellScript>().Direction * speed;
        }   
    }
   

    void CreateSpell(Vector3 src, Vector3 target)
    {
        GameObject lSpell = Instantiate(SpellPrefab) as GameObject;
        lSpell.GetComponent<SpellScript>().Set(src + offset, target);

        listSpells.Add(lSpell);
    }
}
