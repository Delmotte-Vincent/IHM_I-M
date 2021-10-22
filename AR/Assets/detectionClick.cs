using System.Collections;
using System.Collections.Generic;
using System.IO;
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

}
public class detectionClick : MonoBehaviour
{
    Suspects suspects;
    Camera mcamera;
    void Awake()
    {
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
                    case "Hambuger":
                        Debug.Log("Hit Hambuger");
                        break;

                    case "pizza":
                        Debug.Log("Hit Pizza");
                        break;

                    case "Cheese_02":
                        Debug.Log("Hit Cheese");
                        break;

                    case "Steak_Uncooked":
                        Debug.Log("Hit Steak");
                        break;

                    case "Drink_03":
                        Debug.Log("Hit Drink");
                        break;

                    case "Toast":
                        Debug.Log("Hit Toast");
                        break;

                    case "Police_Badge_Modern_01_Tornado_Studio":
                        Debug.Log("Hit Police");
                        break;

                    case "SM_Env_Tree_03":
                        Debug.Log("Hit Tree");
                        break;

                    case "SM_Bld_Apartment_Stack_02":
                        Debug.Log("Hit Apartment");
                        break;

                    case "SM_Prop_LargeSign_Popcorn_01":
                        Debug.Log("Hit Popcorn");
                        break;

                    case "SM_Bld_Shop_01":
                        Debug.Log("Hit Shop");
                        break;

                    case "SM_Wep_ToyGun_OneShot_01":
                        Debug.Log("Hit ToyGun");
                        break;

                    case "SM_Prop_Shelf_01":
                        Debug.Log("Hit Shelf");
                        break;

                    default:
                        Debug.Log("name :" + hit.transform.name + "not registered in code");
                        break;
                }
            }
        }
    }
}
