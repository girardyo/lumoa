using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowStalactite : MonoBehaviour
{
    public int sizeUpMax = 1;
    private float lifeTime = 0f;
    public float lifeTimeMax = 3f;
    private float smooth = 0.3f;
    private Vector3 tailleInitial;
    public GameObject stalactite;
    private bool aCree = false;

    void Start()
    {
        tailleInitial = transform.localScale;
    }

    void Update()
    {
        Vector3 newScale = new Vector3(sizeUpMax, 0.001f, sizeUpMax); // Les dimensions souhaités
        transform.localScale = Vector3.Lerp(tailleInitial, newScale, lifeTime * smooth);
        if (lifeTime < lifeTimeMax)
        {
            if (lifeTime >= 2 && !aCree)
            {
                aCree = true;
                Instantiate(stalactite, new Vector3(transform.position.x, 8, transform.position.z), stalactite.transform.rotation);
            }
            lifeTime = lifeTime + Time.deltaTime;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
