using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public int difficulty = 0;
    public GameObject gamePrefab;
    GameObject newGame;

    public bool isGameMade = false;

    public int playerSkill = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEasy()
    {
        difficulty = 1;
        if (isGameMade == false)
        {
            newGame = Instantiate(gamePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            isGameMade = true;
        }
        else
        {
            Destroy(newGame);
            newGame = Instantiate(gamePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void SetMedium()
    {
        difficulty = 2;
        if (isGameMade == false)
        {
            newGame = Instantiate(gamePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            isGameMade = true;
        }
        else
        {
            Destroy(newGame);
            newGame = Instantiate(gamePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void SetHard()
    {
        difficulty = 3;
        if (isGameMade == false)
        {
            newGame = Instantiate(gamePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            isGameMade = true;
        }
        else
        {
            Destroy(newGame);
            newGame = Instantiate(gamePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
