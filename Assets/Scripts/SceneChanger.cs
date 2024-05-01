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
            LevelLoader.Instance.LoadNextLevel("HubMenu");
        }
    }

    private bool _allFinished()
    {
        int counter = 0;
        foreach (SwipeDetection thing in _thingsToSwipe)
        {
            if (thing.finished)
            {
                counter++;
            }
        }
        if (counter >= 3)
        {
            return true;
        }
        return false;
    }
}
