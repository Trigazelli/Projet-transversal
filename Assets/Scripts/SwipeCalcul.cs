using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SwipeCalcul
{
    public bool DetectUpSwipe(float y1, float y2)
    {
        if (y1 < y2)
        {
            Debug.Log("Swipe up");
            return true;
        }
        return false;
    }

    public bool DetectDownSwipe(float y1, float y2)
    {
        if (y1 > y2)
        {
            Debug.Log("Swipe down");
            return true;
        }
        return false;
    }

    public bool DetectLeftSwipe(float x1, float x2)
    {
        if (x1 > x2)
        {
            Debug.Log("Swipe left");
            return true;

        }
        else if (x1 < x2)
        {
            Debug.Log("Swipe right");
            
        }
        return false;
    }

    public bool DetectRightSwipe(float x1, float x2)
    {
        if (x1 < x2)
        {
            Debug.Log("Swipe right");
            return true;

        }
        return false;
    }
}
