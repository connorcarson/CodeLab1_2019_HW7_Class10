using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private float _horizontalMouse;
    private float _verticalMouse;
    public float speedMultiplier;

    public KeyCode forwardKey;
    public KeyCode backKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;
    
    private Ray _myRay;

    private string _tagStr;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        TranslateCamera();
        Pet();
    }

    private void RotateCamera()
    {
        //get mouse pos on x axis
        _horizontalMouse = Input.GetAxis("Mouse X");
        //get mouse pos on y axis
        _verticalMouse = Input.GetAxis("Mouse Y");
        
        //rotate camera according to mouse pos
        transform.Rotate(-_verticalMouse, _horizontalMouse, 0f);

        //lock z rotation
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        
    }

    private void TranslateCamera()
    {
        if (Input.GetKey(forwardKey))
        {
            transform.Translate(Vector3.forward * speedMultiplier * Time.deltaTime);
        }
        
        if (Input.GetKey(backKey))
        {
            transform.Translate(Vector3.back * speedMultiplier * Time.deltaTime);
        }

        if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector3.left * speedMultiplier * Time.deltaTime);
        }

        if (Input.GetKey(rightKey))
        {
            transform.Translate(Vector3.right * speedMultiplier * Time.deltaTime);
        }

        if (Input.GetKey(jumpKey))
        {
            transform.Translate(Vector3.up * speedMultiplier * Time.deltaTime);
        }
    }
    
    void Pet()
    {
        //initialize ray from camera/player
        _myRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(_myRay.origin, _myRay.direction * 1f, Color.cyan);
        
        //initialize raycastHit
        RaycastHit _myRaycastHit = new RaycastHit();
        
        //if left click
        if (Input.GetMouseButtonDown(0))
        {    
            //and ray is hitting something
            if (Physics.Raycast(_myRay, out _myRaycastHit, 1f))
            {
                //and that something is a dog
                if (_myRaycastHit.transform.gameObject == GameObject.FindWithTag("isDog"))
                {
                    _myRaycastHit.transform.GetComponent<DogMovement>().lovesPlayer = true;
                    Debug.Log("You pet the dog!");
                }
                //if it's a human
                if (_myRaycastHit.transform.gameObject == GameObject.FindWithTag("isHuman"))
                {
                    Debug.Log("You pet the human! They seem confused.");
                }
                else
                {
                    Debug.Log("There's nothing to pet here!");
                }
            }
        }
    }
}