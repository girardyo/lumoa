using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed = 5f;
    public int life = 10;
    public bool slip = false;

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Knockback")
        {
            Debug.Log("touched");
            var a = GameObject.FindGameObjectWithTag("Knockback").transform.position;
            var b = GameObject.FindGameObjectWithTag("Player").transform.position;
            var d = b - a;
            Debug.Log(d);
            GetComponent<Rigidbody>().AddForce(d.normalized * 400f);
            //GetComponent<Rigidbody>().useGravity = true;
        }
    }
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
/*            GameObject.FindGameObjectWithTag("Cone").transform.RotateAround(transform.position, new Vector3(0,1f,0), 50 * Time.deltaTime);*/
            if(slip == true)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, moveSpeed * Time.deltaTime) * 400f);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0.0f, 0.0f, -moveSpeed * Time.deltaTime);
            /*            GameObject.FindGameObjectWithTag("Cone").transform.RotateAround(transform.position, new Vector3(0, 1f, 0), 50 * Time.deltaTime);*/
            if (slip == true)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, -moveSpeed * Time.deltaTime) * 400f);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
            /*GameObject.FindGameObjectWithTag("Cone").transform.RotateAround(transform.position, new Vector3(0, 1f, 0), 50 * Time.deltaTime);*/
            if (slip == true)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f) * 400f);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
            /*GameObject.FindGameObjectWithTag("Cone").transform.RotateAround(transform.position, Vector3.up, 50 * Time.deltaTime);*/
            if (slip == true)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f) * 400f);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0.0f, moveSpeed * Time.deltaTime, 0.0f);
            GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, moveSpeed * Time.deltaTime, 0.0f) * 400f);

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
    public bool getBool()
    {
        return slip;
    }

    public void setBool(bool slip2)
    {
        slip = slip2;
    }
}
