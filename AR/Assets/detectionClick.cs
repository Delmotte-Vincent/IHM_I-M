using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Suspect
{
    public string name { get;}
    public string gender { get;}
    public string thirteen { get; }
    public string fourteen { get; }
    public string fifteen { get; }  
    public string sixteen { get; }
    public string seventeen { get; }
    public string hair { get; }
    public string height { get; }
    public string relation { get; }
    public string transport { get; }
    public string clothing { get; }

    public Suspect(string name, string gender, string thirteen, string fourteen, string fifteen, string sixteen, string seventeen, string hair, string height, string relation, string transport, string clothing)
    {
        this.name = name;
        this.gender = gender;
        this.thirteen = thirteen;
        this.fourteen = fourteen;
        this.fifteen = fifteen;
        this.sixteen = sixteen;
        this.seventeen = seventeen;
        this.hair = hair;
        this.height = height;
        this.relation = relation;
        this.transport = transport;
        this.clothing = clothing;
    }

    public string toString()
    {
        return name + " " + gender + " " + thirteen + " " + fourteen + " " + fifteen + " " + sixteen + " " + seventeen + " " + hair + " " + height + " " + relation + " " + transport + " " + clothing;
    }
}

public class Suspects
{
    private List<Suspect> suspectsList;

    public Suspects() 
    {
        suspectsList = new List<Suspect>();
    }

    public void addSuspect(Suspect suspect)
    {
        suspectsList.Add(suspect);
    }

    public Suspect getSuspect(string Name)
    {
        foreach(Suspect s in suspectsList){
            if (s.name.Equals(Name))
            {
                return s;
            }
        }
        return null;
        
    }
    public Suspect getSuspect(int number)
    {
        return suspectsList[number];
    }

    public string getSuspectInBuilding(string building)
    {
        string thirteen = "13h :";
        string fourteen = "14h :";
        string fifteen = "15h :";
        string sixteen = "16h :";
        string seventeen = "17h :";
        foreach (Suspect s in suspectsList)
        {
            if (s.thirteen.Equals(building))
            {
                thirteen += " " + s.name;
            }
            if (s.fourteen.Equals(building))
            {
                fourteen += " " + s.name;
            }
            if (s.fifteen.Equals(building))
            {
                fifteen += " " + s.name;
            }
            if (s.sixteen.Equals(building))
            {
                sixteen += " 16h : " + s.name;
            }
            if (s.seventeen.Equals(building))
            {
                seventeen += " " + s.name;
            }
        }
        return thirteen + "\n" + fourteen + "\n" + fifteen + "\n" + sixteen + "\n" + seventeen;
    }

}
public class detectionClick : MonoBehaviour
{
    Suspects suspects;
    Camera mcamera;
    GameObject displayText, obj;
    RectTransform rectTransform;
    TextMeshPro text;
    string LastClickedWord;

    void Awake()
    {
        
        displayText = new GameObject();
        obj = GameObject.FindGameObjectWithTag("School");

        displayText.transform.SetParent(obj.transform, true);
        displayText.transform.localScale = new Vector3(2f, 2f, 2f);
        displayText.transform.eulerAngles = new Vector3(90f, 0f, 0f);

        displayText.AddComponent<TextMeshPro>();
        text = displayText.GetComponent<TextMeshPro>();
        text.SetText("test");
        text.enableWordWrapping = false;
        text.gameObject.SetActive(false);
        text.fontSize = 8;
        text.outlineWidth = 0.125f;
        text.fontStyle = FontStyles.Bold;


        rectTransform = displayText.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(0, 0);
        rectTransform.localPosition = new Vector3(0f, 0f, 0f);
        
        suspects = new Suspects();
        string line; 
        string[] suspectCaracteristics;
        FileStream aFile = new FileStream("./suspects.csv", FileMode.Open);
        StreamReader sr = new StreamReader(aFile);

        // read data in line by line
        line = sr.ReadLine();
        line = sr.ReadLine();
        while (line != null)
        {
            suspectCaracteristics = line.Split(',');
            suspects.addSuspect(new Suspect(suspectCaracteristics[0], suspectCaracteristics[1], suspectCaracteristics[2], suspectCaracteristics[3], suspectCaracteristics[4], suspectCaracteristics[5], suspectCaracteristics[6], suspectCaracteristics[7], suspectCaracteristics[8], suspectCaracteristics[9], suspectCaracteristics[10], suspectCaracteristics[11]));
            line = sr.ReadLine();
        }
        Debug.Log(suspects.getSuspect(0).toString());
        sr.Close();
        mcamera = Camera.main;

    }

    void Update()
    {
        // Process a mouse button click.
        if (Input.GetMouseButtonDown(0))
        {

            var ray = mcamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                switch (hit.transform.name)
                {
                    case "SM_Env_Tree_03":
                        Debug.Log("Hit Tree");
                        displayInfo("Park");
                        break;
                    case "SM_Prop_LargeSign_Pizza_01":
                        Debug.Log("Pizza");
                        displayInfo("Pizzeria");
                        break;
                    case "SM_Bld_Apartment_Stack_02":
                        Debug.Log("Hit Apartment");
                        displayInfo("School");
                        break;

                    case "SM_Prop_LargeSign_Popcorn_01":
                        Debug.Log("Hit Popcorn");
                        displayInfo("Theater");
                        break;

                    case "SM_Bld_Shop_01":
                        Debug.Log("Hit Shop");
                        displayInfo("Neighborhood");
                        break;

                    case "SM_Wep_ToyGun_OneShot_01":
                        Debug.Log("Hit ToyGun");
                        break;

                    case "SM_Prop_Shelf_01":
                        Debug.Log("Hit Shelf");
                        displayInfo("Library");
                        break;
                    case "SM_Bld_Shop_Corner_01":
                        Debug.Log("Garden shop");
                        displayInfo("GardenShop");
                        break;
                    case "SM_Bld_Shop_01 (1)":
                        Debug.Log("Market");
                        displayInfo("Market");
                        break;
                    default:
                        Debug.Log("name :" + hit.transform.name + "not registered in code");
                        break;
                }
            }

            //detect word clicked
            var wordIndex = TMP_TextUtilities.FindIntersectingWord(text, Input.mousePosition, Camera.main);

            if (wordIndex != -1)
            {
                LastClickedWord = text.textInfo.wordInfo[wordIndex].GetWord();
                Debug.Log("Clicked on " + LastClickedWord);
            }
        }
    }

    private void displayInfo(string tag)
    {
        if (text.gameObject.activeSelf && obj.tag == tag)
        {
            text.gameObject.SetActive(false);
        }
        else
        {
            text.gameObject.SetActive(true);
        }
        obj = GameObject.FindGameObjectWithTag(tag);
        displayText.transform.SetParent(obj.transform, true);
        rectTransform.localPosition = new Vector3(0f, 0f, 0f);
        text.SetText(suspects.getSuspectInBuilding(tag));
    }
}
