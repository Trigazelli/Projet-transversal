using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private string swipeWanted;

    private float x1;
    private float x2;
    private float y1;
    private float y2;
    private float startTime;
    private int SwipeUp = 0;
    private int SwipeDown = 0;
    private int SwipeLeft = 0;
    private int SwipeRight = 0;

    private void OnMouseEnter()
    {
        x1 = Input.mousePosition.x;
        y1 = Input.mousePosition.y;
    }

    private void OnMouseExit()
    {
        x2 = Input.mousePosition.x;
        y2 = Input.mousePosition.y;
        GetTime();
    }

    private void OnMouseOver()
    {
        IncrementTime();
    }


    private void DetectVerticalSwipe()
    {
        if (y1 > y2)
        {
            Debug.Log("Swipe down");
            SwipeDown++;
        }
        else if (y1 < y2)
        {
            Debug.Log("Swipe up");
            SwipeUp++;
        }
    }

    private void detectHorizontalSwipe()
    {
        if (x1 > x2)
        {
            Debug.Log("Swipe left");
            SwipeLeft++;
        }
        else if (x1 < x2)
        {
            Debug.Log("Swipe right");
            SwipeRight++;
        }
    }

    private void IncrementTime()
    {
        startTime += Time.deltaTime;
    }

    private void GetTime()
    {
        if (startTime > maxTime)
        {
            Debug.Log("pas assez rapide");
        } else
        {
            Debug.Log("Swiped");
            DetectVerticalSwipe();

        }
        startTime = 0f;
    }

    private void Update()
    {
        switch (swipeWanted)
        {
            case "up":
                if (SwipeUp >= 4)
                {
                    LevelLoader.Instance.LoadNextLevel("HubMenu");
                } 
                break;

            case "down":
                if (SwipeDown >= 4)
                {
                    LevelLoader.Instance.LoadNextLevel("HubMenu");
                }
                break;

            case "right":
                if (SwipeRight >= 4)
                {
                    LevelLoader.Instance.LoadNextLevel("HubMenu");
                }
                break;

            case "left":
                if (SwipeLeft >= 4)
                {
                    LevelLoader.Instance.LoadNextLevel("HubMenu");
                }
                break;

            default:
                Debug.Log("SwipeWanted non renseigné");
                break;
        }
    }
}
