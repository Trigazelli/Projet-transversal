using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetection : MonoBehaviour
{
    [HideInInspector] public bool finished;

    [SerializeField] private float maxTime;
    [SerializeField] private string swipeWanted;
    [SerializeField] private Animator anim;

    [SerializeField] private SwipeCalcul _calcul;
    private float x1;
    private float x2;
    private float y1;
    private float y2;
    private float startTime;
    private int Swipe = 0;

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
            Debug.Log("Swiped" + Swipe);
            switch (swipeWanted)
            {
                case "right":
                    if (_calcul.DetectRightSwipe(x1, x2))
                    {
                        Swipe++;
                        anim.SetInteger("State", anim.GetInteger("State") - 1);
                    }
                    break;

                case "left":
                    if (_calcul.DetectLeftSwipe(x1, x2))
                    {
                        Swipe++;
                        anim.SetInteger("State", anim.GetInteger("State") - 1);
                    }
                    break;

                case "up":
                    if (_calcul.DetectUpSwipe(y1, y2))
                    {
                        Swipe++;
                        anim.SetInteger("State", anim.GetInteger("State") - 1);
                    }
                    break;

                case "down":
                    if (_calcul.DetectDownSwipe(y1, y2))
                    {
                        Swipe++;
                        anim.SetInteger("State", anim.GetInteger("State") - 1);
                    }
                    break;

                default:
                    Debug.Log("SwipeWanted non renseigné");
                    break;
            }

        }
        startTime = 0f;
        
        if (Swipe >= 4)
        {
            finished = true;
        }
    }
}
