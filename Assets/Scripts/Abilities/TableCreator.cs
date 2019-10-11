using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCreator : MonoBehaviour
{
    public ThingRuntimeSet playerPositionsSet;
    // Start is called before the first frame update
    void Awake()
    {
        playerPositionsSet.Clear();
        foreach (Transform tr in transform)
            playerPositionsSet.Add(tr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
