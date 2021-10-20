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
    public Transform mainCam;
    GameObject playerCam;
    GameObject playerReal;
    
    enum direction { mv_forward, mv_backward, mv_left, mv_right, left_rotate, right_rotate, none};

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GameObject.Find("PlayerCam");
        playerReal = GameObject.Find("PlayerReal");
    }

    // Update is called once per frame
    void Update()
    {
        direction movementForwardBackward = direction.none, movementRightLeft = direction.none, rotation = direction.none;
        Animator a = playerReal.GetComponentInChildren<Animator>();

        bool walk = false;

        if (Input.GetKey(KeyCode.Z))
        {
            playerReal.transform.position += mainCam.forward * m_speed;
            walk = true;
            movementForwardBackward=direction.mv_forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerReal.transform.position -= mainCam.forward * m_speed;
            walk = true;
            movementForwardBackward=direction.mv_backward;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            playerReal.transform.position -= mainCam.right * m_speed;
            walk = true;
            movementRightLeft=direction.mv_left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerReal.transform.position += mainCam.right * m_speed;
            walk = true;
            movementRightLeft=direction.mv_right;
        }
        
        if (Input.GetKey(KeyCode.J))
        {
            addCubeToScene();
        }
        
        smartCamDisplace(movementForwardBackward, movementRightLeft, rotation);
        a.SetBool("walk", walk);

    }
    
    void addCubeToScene()
    {
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newObject.transform.position = new Vector3(this.playerCam.transform.position.x,
            playerCam.transform.position.y, playerCam.transform.position.z);
    }

    void smartCamDisplace(direction movementForwardBackward = direction.none, direction movementRightLeft = direction.none, direction rotate = direction.none)
    {
        translateCam(movementForwardBackward, movementRightLeft);
        rotateCam(rotate);
        curveCam(movementForwardBackward,rotate);
    }

    //to complete
    void translateCam(direction movFB, direction movRL)
    {
        bool walk = false;

        if (movFB == direction.mv_forward)
        {
            playerCam.transform.position += mainCam.forward * m_speed;
            walk = true;
        }
        if (movFB==direction.mv_backward)
        {
            playerCam.transform.position -= mainCam.forward * m_speed;
            walk = true;
        }
        if (movRL==direction.mv_right)
        {
            playerCam.transform.position += mainCam.right * m_speed;
            walk = true;
        }
        if (movRL==direction.mv_left)
        {
            playerCam.transform.position -= mainCam.right * m_speed;
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
