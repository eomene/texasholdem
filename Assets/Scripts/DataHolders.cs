using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolders 
{
    private static int _startCash = 1000;
    private static float _cardFlySpeed = 1f;
    private static float _cardFlipSpeed = 0.25f;
    private static float _delayBetweenPlayerCreation = .6f;
    private static GameObject _flyingCard;



    public static int startCash
    {
        set { _startCash = value; }
        get { return _startCash; }
    }
    public static float cardFlySpeed
    {
        set { _cardFlySpeed = value; }
        get { return _cardFlySpeed; }
    }
    public static float cardFlipSpeed
    {
        set { _cardFlipSpeed = value; }
        get { return _cardFlipSpeed; }
    }
    public static float delayBetweenPlayerCreation
    {
        set { _delayBetweenPlayerCreation = value; }
        get { return _delayBetweenPlayerCreation; }
    }
    public static GameObject flyingCard
    {
        set { _flyingCard = value; }
        get { return _flyingCard; }
    }

}
