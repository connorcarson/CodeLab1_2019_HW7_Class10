﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1;
    
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        
        
        direction.Normalize();
        
        Quaternion newQuat = Quaternion.LookRotation(direction);

        float dotProduct = Vector3.Dot(direction, transform.forward); 
        
        Debug.DrawRay(transform.position, transform.forward * 5, Color.cyan);
        Debug.DrawRay(transform.position, direction * 5, Color.green);

        if (dotProduct > 0.15f && Vector3.Distance(player.transform.position, transform.position) < 3f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, newQuat, Time.deltaTime * speed);

            if(player.GetComponent<PlayerController>().isPetting)
            {
                Cursor.visible = true;
                Time.timeScale = 0;
                GameManager.instance.losePanel.SetActive(true);
                GameManager.instance.loseText.SetActive(true);
                GameManager.instance.playAgainButton.SetActive(true);
            }
        }
    }
}