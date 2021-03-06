﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Globalization;
using UnityEngine.UI;


public class SongReaderXml : MonoBehaviour
{
    private List<float> listTimecode;
    private List<string> listInput;
    static public bool melody;
    private float T;

    public GameObject projectile;
    public AudioSource audioData;

    public Sprite circle;
    public Sprite triangle;
    public Sprite rectangle;
    public Sprite cross;

    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        listTimecode = new List<float>();
        listInput = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !melody && !SpellController.IsSpellReady || Input.GetKeyDown(KeyCode.JoystickButton5) && !melody && !SpellController.IsSpellReady)
        {
            Debug.Log("start melody");
            audioData.Play(0);
            GetListFromMelody();
            melody = true;
            panel.SetActive(true);
        }

        if (melody)
        {
            T += Time.deltaTime;
            if (listTimecode.Count >= 1 && T > listTimecode[0])
            {
                listInput.RemoveAt(0);
                listTimecode.RemoveAt(0);
            }
            else if (!audioData.isPlaying)
            {
                //melody = false;
                //T = 0;
                ////TODO envoie touche
                //Debug.Log(listInputTemp[0]);
                //listInputTemp.RemoveAt(0);
                //listTimecodeTemp.RemoveAt(0);

                //if(listInputTemp.Count == 0)
                //{
                //    melody = false;
                //    T = 0;
                //}
            }
        }
    }

    void GetListFromMelody()
    {
        XmlDocument doc = new XmlDocument();
        Debug.Log(Application.dataPath + "/Scripts/song.xml");
        doc.Load(Application.dataPath + "/Scripts/song.xml");

        XmlNode root = doc.DocumentElement;

        XmlNode song = root.SelectSingleNode("songconfig");
        XmlNodeList add = song.ChildNodes;

        int i;
        for (i = 0; i < add.Count; i++)
        {
            listTimecode.Add(float.Parse(add[i].Attributes[1].Value, CultureInfo.InvariantCulture.NumberFormat));
            listInput.Add(add[i].Attributes[2].Value);

            InstanciateKey(listInput[i], listTimecode[i]);
        }
        KeyCheckScript.MaxCompletionCount = i;
    }

    void InstanciateKey(string pInput, float pTimecode)
    {
        GameObject lGo = new GameObject(pInput, typeof(Image));
        Sprite lSprite;

        if (pInput == "circle")
            lSprite = circle;
        else if (pInput == "rectangle")
            lSprite = rectangle;
        else if (pInput == "triangle")
            lSprite = triangle;
        else if (pInput == "cross")
            lSprite = cross;
        else
            return;

        lGo.GetComponent<Image>().sprite = lSprite;
        lGo.layer = 5;

        lGo.transform.SetParent(panel.transform);
        lGo.AddComponent<KeyScript>();
        lGo.GetComponent<KeyScript>().xMultiplier = pTimecode;

        KeyCheckScript.keys.Add(lGo);
    }

}
