using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPokerObject
{
    GameObject GetPokerObject { get;}
}
public interface IPokerSpriteFront
{ 
    Sprite GetFront { get; }
}

public interface IPokerSpriteBack
{
    Sprite GetBack { get;  }
}
public interface IPokerOwner
{
    bool fillUp { get; set; }
    bool dontFlip { get; set; }
    bool dontSwap { get; set; }
    bool isRealPlayer { get; set; }
    Transform PokerObject { get; }
    UnityAction action { get; set; }
    float speed { get; set; }
}