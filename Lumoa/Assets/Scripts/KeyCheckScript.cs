using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCheckScript : MonoBehaviour
{
    public static List<GameObject> keys = new List<GameObject>();
    public static bool IsSpellReady = false;
    public static int CompletionCount;
    public static int MaxCompletionCount;

    public float DistanceMax;
    public float CompletionValue;

    // Start is called before the first frame update
    void Start()
    {
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

            //if (CompletionAverage * 100 >= CompletionValue) SpellController.IsSpellReady = true;

            CompletionCount = 0;
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
            return "X";
        //CIRCLE
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            return "B";
        //TRIANGLE
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            return "Y";
        //CROSS
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            return "A";
        else
            return null;
    }
    private void VerifyKey(string playerInput)
    {
        if (DistanceBetween(keys[0]) < DistanceMax && keys[0].name == playerInput && !keys[0].GetComponent<KeyScript>().IsKeyMissed)
        {
            Debug.Log("Good input");

            keys[0].tag = "Success";
            keys.Remove(keys[0]);

            CompletionCount++;
        }
        else
        {
            if (playerInput == null)
                return;

            Debug.Log("Failed input");
            keys[0].GetComponent<KeyScript>().IsKeyMissed = true;
            keys.Remove(keys[0]);
        }
    }

    private float CompletionAverage
    {
        get => (float)CompletionCount / MaxCompletionCount;
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
