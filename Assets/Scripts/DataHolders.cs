using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Holds all data in the game
public static class DataHolders 
{
    //ints
    private static int _startCash = 1000;

    public static int tempCounter = 0;
    public static int indexOfCenterCards = 0;
    //floats
    private static float _delaySpeed = 1f;
    private static float _cardFlipSpeed = 0.25f;
    private static float _delayBetweenPlayerCreation = .6f;
    //GameObjects
    private static GameObject _flyingCard;
    private static GameObject _chip;
    private static GameObject _control;
    //transforms
    private static Transform _mainCanvas;
    private static Transform _chipPositionOnBoard;
    private static Transform _dealerPosition;
    //lists
    //private static List<int> _currentPlayers = new List<int>();
 //   private static List<CardData> _dealerCards = new List<CardData>();
    private static List<PlayerData> _players = new List<PlayerData>();
    private static List<PlayerData> _foldedPlayers = new List<PlayerData>();
    //scripts
    //private static GameController _gameController;
    private static UIDisplay _uIDisplay;
    //events



    public static int startCash
    {
        set { _startCash = value; }
        get { return _startCash; }
    }

    public static float delaySpeed
    {
        set { _delaySpeed = value; }
        get { return _delaySpeed; }
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
    public static GameObject chip
    {
        set { _chip = value; }
        get { return _chip; }
    }
    public static GameObject controls
    {
        set { _control = value; }
        get { return _control; }
    }
    public static Transform mainCanvas
    {
        set { _mainCanvas = value; }
        get { return _mainCanvas; }
    }
    public static Transform chipPositionOnBoard
    {
        set { _chipPositionOnBoard = value; }
        get { return _chipPositionOnBoard; }
    }
    public static Transform dealerPosition
    {
        set { _dealerPosition = value; }
        get { return _dealerPosition; }
    }
    //public static List<int> currentPlayers
    //{
    //    set { _currentPlayers = value; }
    //    get { return _currentPlayers; }
    //}
    //public static List<CardData> dealerCards
    //{
    //    set { _dealerCards = value; }
    //    get { return _dealerCards; }
    //}
    //public static List<PlayerData> players
    //{
    //    set { _players = value; }
    //    get { return _players; }
    //}
    public static List<PlayerData> foldedPlayers
    {
        set { _foldedPlayers = value; }
        get { return _foldedPlayers; }
    }
    //public static GameController gameController
    //{
    //    set { _gameController = value; }
    //    get { return _gameController; }
    //}
    public static UIDisplay uIDisplay
    {
        set { _uIDisplay = value; }
        get { return _uIDisplay; }
    }


}
