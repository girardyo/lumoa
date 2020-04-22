using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyScript : MonoBehaviour
{
    public float RotationSmooth = 5f;
    public bool IsKeyMissed = false;
    private float speed;
    private float fadingSpeed;
    private float width;
    public float xMultiplier;

    private Image image;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        speed = 5.055f;
        fadingSpeed = 1.5f;
        width = GetComponent<RectTransform>().sizeDelta.x;
        image = GetComponent<Image>();
        offset = new Vector3(Center, 0, 0);
        transform.localPosition = offset * xMultiplier * 1.25f;
        tag = "Scrolling";
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Scrolling"))
        {
            Scroll();
        }
        else if(CompareTag("Success"))
        {
            Fade();
        }
        else if (CompareTag("Miss"))
        {
            Fall();
        }
    }
    
    private float Center
    {
        get => transform.parent.GetComponentInParent<RectTransform>().sizeDelta.x / 2;
    }

    void Scroll()
    {
        transform.position += Vector3.left * speed * width * Time.deltaTime;
        if (!IsKeyMissed && transform.position.x < Center - width)
        {
            Debug.Log("Missed key");
            KeyCheckScript.keys.Remove(gameObject);
            IsKeyMissed = true;
        }

        if (IsKeyMissed && transform.position.x < Center - width / 2 + 25)
        {
            tag = "Miss";
        }
    }

    void Fade()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - fadingSpeed * Time.deltaTime);

        if (image.color.a <= 0)
            Destroy(gameObject);
    }

    void Fall()
    {
        //Rotate, fall and fade
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * RotationSmooth);
        transform.position = Vector3.Lerp(transform.position, new Vector3(Center - width, -200, Mathf.Sin(transform.rotation.eulerAngles.z)), Time.deltaTime);
        Fade();
    }
}
