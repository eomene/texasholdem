using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPokerObject
{
    GameObject GetPokerObject();
}
public interface IPokerSpriteFront
{ 
    Sprite GetFront();
}

public interface IPokerSpriteBack
{
    Sprite GetBack();
}
public interface IPokerOwner
{
    bool isRealPlayer();
}