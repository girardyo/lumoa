using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int life = 10;
    public bool slip = false;
    public float slipForce = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
