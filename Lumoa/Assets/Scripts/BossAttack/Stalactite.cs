using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    private Vector3 initialState;
    private float lifeTime = 0f;
    private float lifeTimeMax = 3f;

    void Start () {
     initialState = transform.position;
     }
 
    void Update(){
        if(lifeTime < lifeTimeMax){
            if(lifeTime >= 2f){
            transform.Translate(Vector3.down * Time.deltaTime*40f);
            }
            lifeTime = lifeTime + Time.deltaTime;
        } else {
        Destroy(gameObject);
        }
    }
}