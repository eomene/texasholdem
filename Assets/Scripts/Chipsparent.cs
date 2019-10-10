using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chipsparent : MonoBehaviour, IPokerOwner
{
    public ObjectVariable objectParent;
    public bool isForRealPlayer;
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
}
