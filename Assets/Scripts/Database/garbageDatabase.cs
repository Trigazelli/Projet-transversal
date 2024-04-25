using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewGarbageDatabase", menuName = "Database/Garbage", order = 0)]
public class garbageDatabase : ScriptableObject
{
    public List<GameObject> gameObjects = new();

    // Update is called once per frame
    void Update()
    {
        
    }
}
