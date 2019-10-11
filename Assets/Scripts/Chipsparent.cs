using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chipsparent : MonoBehaviour, IPokerOwner
{
    public Locations startLocation;
    //public Locations endLocation(int id)
    //{
    //    Debug.Log(endLocationsList.Count + "list long");
    //    return endLocationsList[id];
    //}
    //List<Transform> realLocations = new List<Transform>();
    public List<Locations> endLocationsList = new List<Locations>();
    public bool isForRealPlayer;
    public bool fillup = false;
    public bool dontflip = true;
    public bool dontswap = true;
    public Transform parentOfPositions;

    void Awake()
    {
        foreach (Transform tr in parentOfPositions)
        {
            Locations newlocation = new Locations(tr, tr.localPosition, false);
            endLocationsList.Add(newlocation);

        }

        
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
