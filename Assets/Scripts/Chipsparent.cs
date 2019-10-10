using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chipsparent : MonoBehaviour, IPokerOwner
{
    public ObjectVariable objectParent;
    public bool isForRealPlayer;
    const bool fillup = false;
    const bool dontflip = true;
    const bool dontswap = true;
    public void Awake()
    {
        objectParent.Value = gameObject;
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
}
