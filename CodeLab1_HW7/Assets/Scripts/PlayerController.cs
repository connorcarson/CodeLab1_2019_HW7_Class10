﻿using System.Collections;
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

    public bool isPetting = false;

    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        TranslateCamera();
        StartCoroutine(Pet());
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
    
    IEnumerator Pet()
    {
        //initialize ray from camera/player
        _myRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(_myRay.origin, _myRay.direction * 1f, Color.cyan);
        
        //initialize raycastHit
        RaycastHit myRaycastHit = new RaycastHit();
        
 
            //and ray is hitting something
        if (Physics.Raycast(_myRay, out myRaycastHit, 1f))
        {   
            //for every Game Object in allDogs array
            for (int i = 0; i < GameManager.instance.allDogs.Length; i++)
            {   
                //if the Game Object is a Game Object in the allDogs array
                if (myRaycastHit.transform.gameObject == GameManager.instance.allDogs[i])
                { 
                    //and the player clicks that game object
                    if (Input.GetMouseButtonDown(0))
                    {
                        //now you've successfully pet the dog and it loves you, therefore it should stop running around
                        isPetting = true;
                        myRaycastHit.transform.GetComponent<DogMovement>().lovesPlayer = true;
                        ParticleSystem heartParticles =
                            myRaycastHit.transform.GetChild(4).GetComponent<ParticleSystem>();
                        heartParticles.Play();
                        Debug.Log("You pet the dog!");
                    }
                }
            }
            //for every Game Object in allHumans array
            for (int i = 0; i < GameManager.instance.allHumans.Length; i++)
            {                    
                //if the Game Object is a Game Object in the allHumans array
                if (myRaycastHit.transform.gameObject == GameManager.instance.allHumans[i])
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //now you've pet the human
                        Debug.Log("You pet the human! They seem confused.");
                    }
                }
            }
        }
        
        yield return new WaitForSeconds(2f);

        isPetting = false;
    }
}