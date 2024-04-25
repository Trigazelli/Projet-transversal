using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;

    private void Start()
    {
        StartCoroutine(timer());
    }
    public IEnumerator timer()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Perdu loul");
        LevelLoader.Instance.LoadNextLevel("HubMenu");
    }
}
