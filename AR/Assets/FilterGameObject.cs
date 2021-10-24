using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int space=0;
    int h = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject popcorn = GameObject.Find("SM_Prop_LargeSign_Popcorn_01");
            GameObject tree = GameObject.Find("SM_Env_Tree_03");

            if (space == 0){
                popcorn.GetComponent<Renderer>().enabled = false;
                tree.GetComponent<Renderer>().enabled = false;
                space = 1;
            }
            else{
                popcorn.GetComponent<Renderer>().enabled = true;
                tree.GetComponent<Renderer>().enabled = true;
                space = 0;
            }
            
        }

        if (Input.GetKeyDown("h"))
        {
            GameObject appt = GameObject.Find("SM_Bld_Apartment_Stack_02");
            GameObject shop = GameObject.Find("SM_Bld_Shop_01");

            if (h == 0)
            {
                appt.GetComponent<Renderer>().enabled = false;
                shop.GetComponent<Renderer>().enabled = false;
                h = 1;
            }
            else
            {
                appt.GetComponent<Renderer>().enabled = true;
                shop.GetComponent<Renderer>().enabled = true;
                h = 0;
            }

        }
        
    }
}
