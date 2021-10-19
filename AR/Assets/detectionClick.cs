using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionClick : MonoBehaviour
{
    Camera mcamera;
    void Awake()
    {
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
