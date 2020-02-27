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

    // Start is called before the first frame update
    void Start()
    {

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
        {
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
        }
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
