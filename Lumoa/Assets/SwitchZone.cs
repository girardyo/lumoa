using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchZone : MonoBehaviour
{
    public GameObject BossLife;
    public GameObject BottomBar;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        BossLife.SetActive(true);
        BottomBar.SetActive(true);
        Camera.GetComponent<CameraController>().enabled = true;
        Camera.GetComponent<CameraControllerTuto>().enabled = true;
        BossMode.Instance.notAggro = false;
    }
}
