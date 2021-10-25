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
    int f=0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            GameObject popcorn = GameObject.Find("SM_Prop_LargeSign_Popcorn_01");
            GameObject bar = GameObject.Find("SM_Bld_Shop_Corner_01 (2)");
            GameObject range = GameObject.Find("SM_Bld_Shop_Corner_01 (1)");
            GameObject neighbourhood = GameObject.Find("SM_Bld_OfficeOld_Small_Base_01");
            GameObject library = GameObject.Find("SM_Bld_Shop_01");
            GameObject market = GameObject.Find("SM_Bld_Shop_01 (1)");
            GameObject pizza = GameObject.Find("SM_Prop_LargeSign_Pizza_01");
            GameObject garden = GameObject.Find("SM_Bld_Shop_Corner_01");

            if (space == 0){
                popcorn.GetComponent<Renderer>().enabled = false;
                bar.GetComponent<Renderer>().enabled = false;
                range.GetComponent<Renderer>().enabled = false;
                neighbourhood.GetComponent<Renderer>().enabled = false;
                library.GetComponent<Renderer>().enabled = false;
                market.GetComponent<Renderer>().enabled = false;
                pizza.GetComponent<Renderer>().enabled = false;
                garden.GetComponent<Renderer>().enabled = false;
                space = 1;
            }
            else{
                popcorn.GetComponent<Renderer>().enabled = true;
                bar.GetComponent<Renderer>().enabled = true;
                range.GetComponent<Renderer>().enabled = true;
                neighbourhood.GetComponent<Renderer>().enabled = true;
                library.GetComponent<Renderer>().enabled = true;
                market.GetComponent<Renderer>().enabled = true;
                pizza.GetComponent<Renderer>().enabled = true;
                garden.GetComponent<Renderer>().enabled = true;
                space = 0;
            }
            
        }

        if (Input.GetKeyDown("e"))
        {
            GameObject bar = GameObject.Find("SM_Bld_Shop_Corner_01 (2)");
            GameObject school = GameObject.Find("SM_Bld_Apartment_Stack_02");
            GameObject range = GameObject.Find("SM_Bld_Shop_Corner_01 (1)");
            GameObject neighbourhood = GameObject.Find("SM_Bld_OfficeOld_Small_Base_01");
            GameObject library = GameObject.Find("SM_Bld_Shop_01");
            GameObject popcorn = GameObject.Find("SM_Prop_LargeSign_Popcorn_01");
            GameObject tree = GameObject.Find("SM_Env_Tree_03");
            GameObject pizza = GameObject.Find("SM_Prop_LargeSign_Pizza_01");

            if (h == 0)
            {
                bar.GetComponent<Renderer>().enabled = false;
                school.GetComponent<Renderer>().enabled = false;
                range.GetComponent<Renderer>().enabled = false;
                neighbourhood.GetComponent<Renderer>().enabled = false;
                library.GetComponent<Renderer>().enabled = false;
                popcorn.GetComponent<Renderer>().enabled = false;
                tree.GetComponent<Renderer>().enabled = false;
                pizza.GetComponent<Renderer>().enabled = false;
                h = 1;
            }
            else
            {
                bar.GetComponent<Renderer>().enabled = true;
                school.GetComponent<Renderer>().enabled = true;
                range.GetComponent<Renderer>().enabled = true;
                neighbourhood.GetComponent<Renderer>().enabled = true;
                library.GetComponent<Renderer>().enabled = true;
                popcorn.GetComponent<Renderer>().enabled = true;
                tree.GetComponent<Renderer>().enabled = true;
                pizza.GetComponent<Renderer>().enabled = true;
                h = 0;
            }

        }
        
    }

   
}
