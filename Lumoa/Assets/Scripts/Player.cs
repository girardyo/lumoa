using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int life = 10;
    public bool slip = false;
    public float slipForce = 50f;
    public bool knockback = false;
    public float knockTimer = 0f;


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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knockback")
        {
            Debug.Log("touched");
            var a = GameObject.FindGameObjectWithTag("Knockback").transform.position;
            var b = GameObject.FindGameObjectWithTag("Player").transform.position;
            var d = b - a;
            GetComponent<Rigidbody>().AddForce(new Vector3(d.x, 0, d.z) * 800f);
            knockback = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (knockback)
        {
            if (knockTimer < 0.4f)
            {
                knockTimer = knockTimer + Time.deltaTime;
            }
            else
            {
                knockTimer = 0;
                knockback = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }

        else
        {/*
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0.0f, 0.0f, moveSpeed * Time.deltaTime);
                if (slip == true)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, moveSpeed * Time.deltaTime) * slipForce);
                }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0.0f, 0.0f, -moveSpeed * Time.deltaTime);
                if (slip == true)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, -moveSpeed * Time.deltaTime) * slipForce);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
                if (slip == true)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f) * slipForce);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
                if (slip == true)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f) * slipForce);
                }
            }
        }*/







            //Store the current horizontal input in the float moveHorizontal.
            float moveHorizontal = Input.GetAxis("Horizontal");

            //Store the current vertical input in the float moveVertical.
            float moveVertical = Input.GetAxis("Vertical");

            //Use the two store floats to create a new Vector2 variable movement.
            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            rigibody.AddForce(movement * speed);

            if (rigibody.velocity.magnitude > .5f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rigibody.velocity), Time.deltaTime * speedRotation);
                Debug.Log("walk");

                AnimManager.LaunchAnim(animator, "Walk");
            }
            else if (rigibody.velocity.magnitude > 6f)
            {
                AnimManager.LaunchAnim(animator, "Run_forward");

            }
            else
            {
                AnimManager.LaunchAnim(animator, "Idle_breathing");
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton6) || Input.GetKeyDown(KeyCode.LeftShift))
            {

                if (canIDash)
                {

                    StartCoroutine(Dash());
                }
                canIDash = false;


            }
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

public int getLife() 
    {
        return life;
    }

public void setLife(int life2)
    {
        life = life2;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public void setMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public bool getBool()
    {
        return slip;
    }

    public void setBool(bool slip2)
    {
        slip = slip2;
    }
}
