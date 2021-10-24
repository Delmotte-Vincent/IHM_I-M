using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationAndZoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y, 
                gameObject.transform.eulerAngles.z + 2.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y + 2.5f,
                gameObject.transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x ,
                gameObject.transform.eulerAngles.y,
                gameObject.transform.eulerAngles.z - 2.5f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y - 2.5f,
                gameObject.transform.eulerAngles.z);
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0f && gameObject.transform.localScale.x < 0.35)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.01f,
                gameObject.transform.localScale.y + 0.01f,
                gameObject.transform.localScale.z + 0.01f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && gameObject.transform.localScale.x > 0.03)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.01f,
                gameObject.transform.localScale.y - 0.01f,
                gameObject.transform.localScale.z - 0.01f);
        }
    }
}
