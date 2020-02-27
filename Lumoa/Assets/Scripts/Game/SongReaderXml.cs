using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class SongReaderXml : MonoBehaviour
{

    private List<string> listTimecode = new List<string>();
    private List<string> listInput = new List<string>();
    private bool melody;
    private float T;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("start melody");
            audioData.Play(0);
            getListFromMelody();
            melody = true;

        }
        if (melody == true)
        {
            List<string> listTimecodeTemp = new List<string>();
            listTimecodeTemp = listTimecode;
            List<string> listInputTemp = new List<string>();
            listInputTemp = listInput;
            T += Time.deltaTime;
            if (T > float.Parse(listTimecodeTemp[0]))
            {
                //TODO envoie touche
                Debug.Log(listInputTemp[0]);
                listInputTemp.RemoveAt(0);
                listTimecodeTemp.RemoveAt(0);

                if(listInputTemp.Count == 0)
                {
                    melody = false;
                    T = 0;
                }
            }

        }

    }

    void getListFromMelody()
    {
        XmlDocument doc = new XmlDocument();
        Debug.Log(Application.dataPath + "/Scripts/song.xml");
        doc.Load(Application.dataPath + "/Scripts/song.xml");

        XmlNode root = doc.DocumentElement;

        XmlNode song = root.SelectSingleNode("songconfig");
        XmlNodeList add = song.ChildNodes;
        for (int i = 0; i < add.Count; i++)
        {
            listTimecode.Add(add[i].Attributes[1].Value);
            listInput.Add(add[i].Attributes[2].Value);

        }

    }

}
