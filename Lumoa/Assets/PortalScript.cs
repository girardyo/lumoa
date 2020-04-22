using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalScript : MonoBehaviour
{
    public Animator animator;
    public Image image;
    public Rigidbody rb;
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
        AnimManager.LaunchAnim(animator, "BlackFade");
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f&& animator.GetCurrentAnimatorStateInfo(0).IsName("BlackFade") )
            Debug.Log("playing"); SceneManager.LoadScene("UI");

    }
}
