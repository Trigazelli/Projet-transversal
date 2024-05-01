using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCount : MonoBehaviour
{
    [SerializeField] private List<string> strings;


    private int compteur;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (strings.Count == 0)
        {
            compteur++;
            strings.Add(collision.gameObject.name);
        }
        foreach (string name in strings)
        {
            if (collision.gameObject.name != name)
            {
                compteur++;
                strings.Add(collision.gameObject.name);
                break;
            }
        }
    }

    private void Update()
    {
        Debug.Log("compteur :" + compteur);
        if (compteur >= 3)
        {
            LevelLoader.Instance.LoadNextLevel();
        }
    }
}
