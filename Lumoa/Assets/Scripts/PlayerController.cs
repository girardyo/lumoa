using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float maxSpeed = 7;
    public Animator animator;
    private Rigidbody rigibody;
    public GameObject trailRenderer;
    private bool canIDash = true;
    public float speedRotation;

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rigibody.AddForce(movement* speed);

        if (rigibody.velocity.magnitude > .5f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rigibody.velocity), Time.deltaTime * speedRotation);
            Debug.Log("walk");

            AnimManager.LaunchAnim(animator, "Walk");
        }
        else if(rigibody.velocity.magnitude > 6f)
        {
            AnimManager.LaunchAnim(animator, "Run_forward");

        }
        else
        {
            AnimManager.LaunchAnim(animator, "Idle_breathing");
        }

        if(Input.GetKeyDown(KeyCode.JoystickButton4)|| Input.GetKeyDown(KeyCode.JoystickButton6) || Input.GetKeyDown(KeyCode.LeftShift)){

            if (canIDash)
            {

                StartCoroutine(Dash());
            }
            canIDash = false;


            


        }

    }
    void FixedUpdate()
    {


        if (rigibody.velocity.magnitude > maxSpeed)
        {
            rigibody.velocity = rigibody.velocity.normalized * maxSpeed;
        }
    }

    IEnumerator Dash()
    {

        trailRenderer.SetActive(true);
        rigibody.AddForce(10000 * transform.forward);
        yield return new WaitForSeconds(0.5f);
        trailRenderer.SetActive(false);
        yield return new WaitForSeconds(3f);
        canIDash = true;


    }



}
