using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private SwipeDetection[] _thingsToSwipe;

    private void Update()
    {
        if (_allFinished())
        {
            LevelLoader.Instance.LoadNextLevel();
        }
    }

    private bool _allFinished()
    {
        int counter = 0;
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
