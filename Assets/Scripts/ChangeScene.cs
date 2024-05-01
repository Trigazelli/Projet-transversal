using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string scene;

    private void OnMouseDown()
    {
        LevelLoader.Instance.LoadNextLevel();
    }
}
