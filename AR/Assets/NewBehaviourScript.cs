using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ReadCsvfile();
    }

    void ReadCsvfile(){

        StreamReader strReader = new StreamReader("");
        bool endOfFile=false;

        while(!endOfFile){

            string data_String = strReader.ReadLine();
            if( data_String==null){
                endOfFile=true;
                break;
            }

            var data_valeurs=data_String.Split(',');

            for(int i=0;i<data_valeurs.Length;i++){
                Debug.Log("Value:"+i.ToString()+" "+ data_valeurs.ToString());
            }

            //Debug.Log(data_valeurs[0].ToString+' '+data_valeurs[1].ToString);
        }
    }
}
