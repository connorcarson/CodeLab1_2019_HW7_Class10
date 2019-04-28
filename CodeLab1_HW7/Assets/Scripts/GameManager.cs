using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            PairSpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PairSpawn()
    {
        GameObject newPair = Instantiate(Resources.Load<GameObject>("Prefabs/Pair"));
        newPair.transform.position = new Vector3(Random.Range(-20, 20), .7f, Random.Range(-20, 20));
        newPair.transform.eulerAngles = new Vector3(transform.eulerAngles.x, Random.Range(0, 360), transform.eulerAngles.z);
    }
}
