using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    private Quaternion _startRot;

    public GameObject human;
    public float speedMultiplier;

    public bool lovesPlayer = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (lovesPlayer == false)
        {
            RotateDog();
        }
        else
        {;
            return;
        }
    }

    void RotateDog()
    {
        transform.RotateAround(human.transform.position, Vector3.up, 1 * speedMultiplier);
    }
}
