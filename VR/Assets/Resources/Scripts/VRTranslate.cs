using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTranslate : MonoBehaviour
{
    public float translate_gain = 1.0f;
    public float rotation_gain = 1.0f;
    public float curvature_gain = 1.0f;

    public float m_speed = 0.01f;
    public float r_speed = 0.1f;
    GameObject playerCam;
    GameObject playerReal;

    enum direction { mv_forward, mv_backward, left_rotate, right_rotate, none};

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GameObject.Find("PlayerCam");
        playerReal = GameObject.Find("PlayerReal");
    }

    // Update is called once per frame
    void Update()
    {
        direction movement = direction.none, rotation = direction.none;
        Animator a = playerReal.GetComponentInChildren<Animator>();

        bool walk = false;

        if (Input.GetKey(KeyCode.W))
        {
            playerReal.transform.position += playerReal.transform.forward * m_speed;
            walk = true;
            movement=direction.mv_forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerReal.transform.position += -playerReal.transform.forward * m_speed;
            walk = true;
            movement=direction.mv_backward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerReal.transform.eulerAngles -= new Vector3(0.0f, r_speed, 0.0f);

        }
        if (Input.GetKey(KeyCode.D))
        {
            playerReal.transform.eulerAngles += new Vector3(0.0f, r_speed, 0.0f);
        }

        smartCamDisplace(movement,rotation);
        a.SetBool("walk", walk);

    }

    void smartCamDisplace(direction movement = direction.none, direction rotate = direction.none)
    {
        translateCam(movement);
        rotateCam(rotate);
        curveCam(movement,rotate);
    }

    //to complete
    void translateCam(direction mov){
        bool walk = false;

        if (mov==direction.mv_forward)
        {
            playerCam.transform.position += playerReal.transform.forward * m_speed;
            walk = true;
        }
        if (mov==direction.mv_backward)
        {
            playerCam.transform.position += -playerReal.transform.forward * m_speed;
            walk = true;
        }

    }

    //to complete
    void rotateCam(direction rot)
    {
        playerCam.transform.rotation = playerReal.transform.rotation;
    }

    //to complete
    void curveCam(direction mov, direction rot)
    {
        
    }

}
