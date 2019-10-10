using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chipsparent : MonoBehaviour, IPokerOwner
{
    public Locations startLocation;
    public Locations endLocation(int id)
    {
        Locations newlocation = new Locations(realLocations[id], realLocations[id].localPosition, false);
        return newlocation;
    }
    public List<Transform> realLocations = new List<Transform>();
    public bool isForRealPlayer;
    const bool fillup = false;
    const bool dontflip = true;
    const bool dontswap = true;

    void Awake()
    {
        foreach (Transform tr in transform)
            realLocations.Add(tr);

       // startLocation = new Locations(realLocations[0], realLocations[0].transform.position, false);
    }
    bool IPokerOwner.isRealPlayer() 
    {
        return isForRealPlayer;
    }

    public Transform PokerObject()
    {
        return transform;
    }

    public bool fillUp()
    {
        return fillup; 
    }

    public bool dontFlip()
    {
        return dontflip;

    }

    public bool dontSwap()
    {
        return dontswap;
    }

    public Action action = new Action(finishedMovement);

    public static void finishedMovement()
    {
        Debug.Log("finished moving on chips parent");
    }

    Action IPokerOwner.action()
    {
       
        return action;
    }
}
