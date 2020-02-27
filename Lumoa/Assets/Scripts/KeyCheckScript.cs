using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCheckScript : MonoBehaviour
{
    public float DistanceMax;
    private Text completionText;
    private Slider completionGauge;
    public float CompletionValue;
    public static int CompletionCount;
    public static int MaxCompletionCount;
    public static List<GameObject> keys = new List<GameObject>();
    public static bool IsSpellReady = false;

    // Start is called before the first frame update
    void Start()
    {
        completionText = transform.GetChild(0).gameObject.GetComponent<Text>();
        completionGauge = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Slider>();
        completionText.text = "0%";
    }

    // Update is called once per frame
    void Update()
    {
        if (keys.Count > 0)
        {
            VerifyKey(VerifyInput());
        }
        else if (transform.parent.childCount == 1)
        {
            transform.parent.gameObject.SetActive(false);

            if (CompletionAverage * 100 >= CompletionValue) SpellController.IsSpellReady = true;

            CompletionCount = 0;
            completionGauge.value = 0;
            completionText.text = CompletionAverage * 100 + "%";
        }
    }

    private float DistanceBetween(GameObject key)
    {
        return Mathf.Sqrt(Mathf.Pow((key.transform.position.x - transform.position.x), 2f));
    }

    private string VerifyInput()
    {
        //RECTANGLE
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            return "rectangle";
        //CIRCLE
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            return "circle";
        //TRIANGLE
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            return "triangle";
        //CROSS
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            return "cross";
        else
            return null;
    }
    private void VerifyKey(string playerInput)
    {
        if (DistanceBetween(keys[0]) < DistanceMax && keys[0].name == playerInput)
        {
            Debug.Log("Good input");
            
            keys[0].tag = "Success";
            keys.Remove(keys[0]);

            CompletionCount++;
            completionText.text = CompletionAverage * 100 + "%";
            completionGauge.value = CompletionAverage;
        }
        else
        {
            if (playerInput == null)
                return;

            Debug.Log("Failed input");

            keys[0].tag = "Miss";
            keys.Remove(keys[0]);
        }
    }

    private float CompletionAverage
    {
        get => (float) CompletionCount / MaxCompletionCount;
    }

    public static void ResetKeyChecker()
    {
        Debug.Log("reset");
        CompletionCount = 0;
        SpellController.IsSpellReady = false;
        SongReaderXml.melody = false;
        keys.Clear();
    }

}
