using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyScript : MonoBehaviour
{
    public bool IsKeyMissed = false;
    public float songPosition;
    public float offsetY;

    private float speed;
    private float width;

    private float rotationSmooth;
    private float fallingSmooth;
    private Image image;
    private float fadingSpeed;

    // Use this for initialization
    void Start()
    {
        tag = "Scrolling";

        transform.localPosition = new Vector3(CheckPosition.x * songPosition / 5, offsetY, 0);
        speed = DistanceBetween(transform.position) / songPosition;
        width = GetComponent<RectTransform>().sizeDelta.x * GetComponent<RectTransform>().lossyScale.x;

        rotationSmooth = 1.5f;
        fallingSmooth = 0.25f;
        image = GetComponent<Image>();
        fadingSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Scrolling"))
        {
            Scroll();
        }
        else if (CompareTag("Success"))
        {
            Rise();
        }
        else if (CompareTag("Miss"))
        {
            Fall();
        }
    }

    private Vector3 CheckPosition
    {
        get => transform.parent.Find("Check").position;
    }

    private float DistanceBetween(Vector3 key)
    {
        return Mathf.Sqrt(Mathf.Pow((key.x - CheckPosition.x), 2f));
    }

    void Scroll()
    {
        if (IsKeyMissed)
        {
            tag = "Miss";
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (!IsKeyMissed && transform.position.x < CheckPosition.x - width / 2)
        {
            Debug.Log("Missed key");
            KeyCheckScript.keys.Remove(gameObject);
            IsKeyMissed = true;
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
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * rotationSmooth);
        transform.position = Vector3.Lerp(transform.position, new Vector3(CheckPosition.x, -200, Mathf.Sin(transform.rotation.eulerAngles.z)), Time.deltaTime * fallingSmooth);
        Fade();
    }

    void Rise()
    {
        //Rotate, rise and fade
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * rotationSmooth);
        transform.position = Vector3.Lerp(transform.position, new Vector3(CheckPosition.x, 200, Mathf.Sin(transform.rotation.eulerAngles.z)), Time.deltaTime * fallingSmooth);
        Fade();
    }
}
