using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRevenge : MonoBehaviour
{
    [SerializeField] private SwipeDetection[] _thingsToSwipe;

    int counter = 0;

    private void Update()
    {
        if (_allFinished())
        {
            LevelLoader.Instance.LoadNextLevel();
        }
    }

    private bool _allFinished()
    {
        foreach (SwipeDetection thing in _thingsToSwipe)
        {
            Debug.Log(thing.finished);
            if (thing.finished)
            {
                counter++;
            }
        }
        if (counter >= _thingsToSwipe.Length)
        {
            return true;
        }
        return false;
    }
}
