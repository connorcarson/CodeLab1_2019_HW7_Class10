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

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        TranslateCamera();
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
}