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
    public Camera camera;
    GameObject playerRealVR;
    GameObject playerReal;

    public GameObject gun;
    public GameObject pan;
    public GameObject can;
    public GameObject bottle;
    
    enum direction { mv_forward, mv_backward, mv_left, mv_right, left_rotate, right_rotate, none};

    // Start is called before the first frame update
    void Start()
    {
        playerRealVR = GameObject.Find("PlayerRealVR");
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
        
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            addItemToScene(gun);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            addItemToScene(pan);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            addItemToScene(can);
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            addItemToScene(bottle);
        }

        smartCamDisplace(movementForwardBackward, movementRightLeft, rotation);
        a.SetBool("walk", walk);

    }
    
    void addItemToScene(GameObject item)
    {
        item.AddComponent<PickableObject>();
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            Vector3 objectHit = hit.point;
            item.transform.position = objectHit+Vector3.up/2;
        }
        Instantiate(item, item.transform.position, Quaternion.identity);
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
            playerRealVR.transform.position += mainCam.forward * m_speed;
            walk = true;
        }
        if (movFB==direction.mv_backward)
        {
            playerRealVR.transform.position -= mainCam.forward * m_speed;
            walk = true;
        }
        if (movRL==direction.mv_right)
        {
            playerRealVR.transform.position += mainCam.right * m_speed;
            walk = true;
        }
        if (movRL==direction.mv_left)
        {
            playerRealVR.transform.position -= mainCam.right * m_speed;
            walk = true;
        }

    }

    //to complete
    void rotateCam(direction rot)
    {
        playerRealVR.transform.rotation = playerReal.transform.rotation;
    }

    //to complete
    void curveCam(direction mov, direction rot)
    {

    }

}
