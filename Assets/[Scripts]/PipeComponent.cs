using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeComponent : MonoBehaviour
{
    // Float Array of starting rotations
    float[] possibleStartingRotation =
    {
        0, 90, 180, 270
    };

    // Float array of each pipe's correct roations
    public float[] correctRotations;
    // Check if the pipe is in the right rotation
    public bool isCorrectRotation;
    // Some pipes will have more than 1 possible rotation
    int possibleRotations = 1;


    void Start()
    {
        // Set possible rotations to however large the array is
        possibleRotations = correctRotations.Length;
        // Set random starting rotation
        int randomRotation = Random.Range(0, possibleStartingRotation.Length);
        transform.eulerAngles = new Vector3(0, 0, possibleStartingRotation[randomRotation]);

        // If more than one, check both if it's in the correct rotation already, otherwise check just the one
        if (possibleRotations > 1)
        {
            if (transform.eulerAngles.z == correctRotations[0] ||
                transform.eulerAngles.z == correctRotations[1])
            {
                if (isCorrectRotation == false)
                {
                    isCorrectRotation = true;
                    GameManager.Instance.IncrementCorrectPipesAndCheckForWin();
                }
            }
            else
            {
                if (isCorrectRotation == true)
                {
                    isCorrectRotation = false;
                    GameManager.Instance.DecrementCorrectPipes();
                }
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotations[0])
            {
                if (isCorrectRotation == false)
                {
                    isCorrectRotation = true;
                    GameManager.Instance.IncrementCorrectPipesAndCheckForWin();
                }
            }
            else
            {
                if (isCorrectRotation == true)
                {
                    isCorrectRotation = false;
                    GameManager.Instance.DecrementCorrectPipes();
                }
            }
        }
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.hasWon == false && GameManager.Instance.hasLost == false)
        {
            // Rotate it 90 degrees
            transform.Rotate(new Vector3(0, 0, 90.000000000f));

            // Check once again if it's in any of the correct rotations
            if (possibleRotations > 1)
            {
                if (transform.eulerAngles.z == correctRotations[0] ||
                    transform.eulerAngles.z == correctRotations[1])
                {
                    if (isCorrectRotation == false)
                    {
                        isCorrectRotation = true;
                        GameManager.Instance.IncrementCorrectPipesAndCheckForWin();
                    }
                }
                else
                {
                    if (isCorrectRotation == true)
                    {
                        isCorrectRotation = false;
                        GameManager.Instance.DecrementCorrectPipes();
                    }
                }
            }
            else
            {
                if (transform.eulerAngles.z == correctRotations[0])
                {
                    if (isCorrectRotation == false)
                    {
                        isCorrectRotation = true;
                        GameManager.Instance.IncrementCorrectPipesAndCheckForWin();
                    }
                }
                else
                {
                    if (isCorrectRotation == true)
                    {
                        isCorrectRotation = false;
                        GameManager.Instance.DecrementCorrectPipes();
                    }
                }
            }
        }
    }
}
