using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMoverParent
{
    UnityAction action { get; set; }
    bool dontFlip { get; set; }
    bool dontSwap { get; set; }
    bool fillUp { get; set; }
    bool isRealPlayer { get; set; }
    Transform PokerObject { get; }
    float speed { get; set; }

    Transform parentOfPositionsInterface();

}

public class MoverParent : MonoBehaviour, IPokerOwner, IMoverParent
{
    public Locations startLocation;
    public List<Locations> endLocationsList = new List<Locations>();
    public Transform parentOfPositions;
    public float movespeed = 1;

    void Awake()
    {
        foreach (Transform tr in parentOfPositions)
        {
            Locations newlocation = new Locations(tr, tr.localPosition, false);
            endLocationsList.Add(newlocation);

        }

    }
    public Transform parentOfPositionsInterface()
    {
        return parentOfPositions;
    }

    public UnityAction actionReal;
    public bool fillUp { get; set; }
    public bool dontFlip { get; set; }
    public bool dontSwap { get; set; }
    public bool isRealPlayer { get; set; }
    public Transform PokerObject { get { return transform; } }
    public UnityAction action { get; set; }
    public float speed { get { return movespeed; } set { movespeed = value; } }

}
