using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject losePanel;
    public GameObject loseText;
    public GameObject playAgainButton;
    public GameObject cursor;
    public GameObject petCursor;
    
    public GameObject[] allDogs;
    public GameObject[] allHumans;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        instance = this;
        /*if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }*/
        
        for (int i = 0; i < 15; i++)
        {
            PairSpawn();
        }
        
        allDogs = GameObject.FindGameObjectsWithTag("isDog");
        allHumans = GameObject.FindGameObjectsWithTag("isHuman");
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

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
