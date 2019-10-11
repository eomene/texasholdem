﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoverParent : MonoBehaviour, IPokerOwner
{
    public Locations startLocation;
    public List<Locations> endLocationsList = new List<Locations>();
    public bool isForRealPlayer;
    public bool fillup = false;
    public bool dontflip = true;
    public bool dontswap = true;
    public Transform parentOfPositions;
    public float movespeed = 1;

    void Awake()
    {
        foreach (Transform tr in parentOfPositions)
        {
            Locations newlocation = new Locations(tr, tr.localPosition, false);
            endLocationsList.Add(newlocation);

        }

        actionReal += finishedMovement;

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

    public UnityAction actionReal;

    public static void finishedMovement()
    {
        Debug.Log("finished moving on chips parent");
    }

    UnityAction IPokerOwner.action()
    {
        return actionReal;
    }

    public float speed()
    {
        return movespeed;
    }
}