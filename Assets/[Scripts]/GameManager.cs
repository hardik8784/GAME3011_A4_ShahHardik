using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public Canvas resultCanvas;
    public TMP_Text resultText;
    public GameObject ExitButton;

    Controller controller;

    public GameObject easy;
    public GameObject medium;
    public GameObject hard;
    // GameObject holding our pipes
    public GameObject pipeHolderEasy;
    public GameObject pipeHolderMedium;
    public GameObject pipeHolderHard;
    GameObject pipeHolder;
    // Pipes being held
    public GameObject[] pipes;
    // Count of how many pipes we've got
    public int numberOfPipes = 0;

    // Number of currently correct pipes
    public int correctPipes = 0;
    // Check if we've won
    public bool hasWon = false;
    public bool hasLost = false;

    // Start is called before the first frame update
    void Start()
    {
        resultCanvas.enabled = false;
        controller = GameObject.FindObjectOfType<Controller>();

        // Set up which board will become active based on difficulty
        if (controller.difficulty == 1 /*|| controller.difficulty == 2*/)
        {
            pipeHolder = pipeHolderEasy;
            easy.SetActive(true);
            medium.SetActive(false);
            hard.SetActive(false);
        }
        else if(controller.difficulty ==2)
        {
            pipeHolder = pipeHolderMedium;
            easy.SetActive(false);
            medium.SetActive(true);
            hard.SetActive(false);
        }
        else if (controller.difficulty == 3)
        {
            pipeHolder = pipeHolderHard;
            easy.SetActive(false);
            medium.SetActive(false);
            hard.SetActive(true);
        }

        // Set up the timer based on difficulty                                             Could probably do both of these at the same time lol oops
        switch (controller.difficulty)
        {
            case 1:
                {
                    timeRemaining = 120 + controller.playerSkill;
                    break;
                }
            case 2:
                {
                    timeRemaining = 60 + controller.playerSkill;
                    break;
                }
            case 3:
                {
                    timeRemaining = 120 + controller.playerSkill;
                    break;
                }
        }

        // Set number of pipes to the amount of children in our empty game object holding all the pipes
        numberOfPipes = pipeHolder.transform.childCount;
        // Reinitialize the arraw with the numberOfPipes as the size
        pipes = new GameObject[numberOfPipes];
        // For every pipe in the array, set the gameObject to each child respectively
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = pipeHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Timer stuff
        if (hasLost == false && hasWon == false)
        {
            Timer();
            DisplayTime(timeRemaining);
        }
    }

    public void IncrementCorrectPipesAndCheckForWin()
    {
        //Debug.Log("Checking");
        correctPipes += 1;
        if (correctPipes >= numberOfPipes)
        {
            hasWon = true;
            resultCanvas.enabled = true;
            controller.playerSkill += 10;
            resultText.text = "You win!";
            Debug.Log("Correct: " + correctPipes + " out of " + numberOfPipes.ToString());
        }
    }

    public void DecrementCorrectPipes()
    {
        correctPipes -= 1;
    }

    float timeRemaining;
    public TMP_Text timeText;

    void Timer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            hasLost = true;
            resultCanvas.enabled = true;
            resultText.text = "You lose!";
            Debug.Log("Time is up");
            ExitButton.SetActive(true);
        }
    }

    void DisplayTime(float _time)
    {
        float minutes = Mathf.FloorToInt(_time / 60);
        float seconds = Mathf.FloorToInt(_time % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
