using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Holds all data in the game
public static class DataHolders 
{
    //ints
    private static int _startCash = 1000;
    private static int _lastBet = 0;
    private static int _currentTurn = 1;
    private static int _totalBetOfRound = 0;
    private static int _gameRound = 0;
    public static int tempCounter = 0;
    public static int indexOfCenterCards = 0;
    //floats
    private static float _delaySpeed = .05f;
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
    private static List<CardData> _dealerCards = new List<CardData>();
    private static List<PlayerData> _players = new List<PlayerData>();
    private static List<PlayerData> _foldedPlayers = new List<PlayerData>();
    //scripts
    private static GameController _gameController;
    private static UIDisplay _uIDisplay;
    //events
    public static UnityEvent onPlayerTurnUpdated = new UnityEvent();
    public static UnityEvent onRoundUpdated = new UnityEvent();
    public static UnityEvent onTotalBetUpdated = new UnityEvent();


    public static int startCash
    {
        set { _startCash = value; }
        get { return _startCash; }
    }
    public static int lastBet
    {
        set { _lastBet = value; }
        get { return _lastBet; }
    }
    public static int currentTurn
    {
        set
        {
            _currentTurn = value;
            if (onPlayerTurnUpdated != null)
                onPlayerTurnUpdated.Invoke();
        }
        get { return _currentTurn; }
    }
    public static int totalBetOfRound
    {
        set
        {
            _totalBetOfRound = value;
            if (onTotalBetUpdated != null)
                onTotalBetUpdated.Invoke();
        }
        get { return _totalBetOfRound; }
    }
    public static int gameRound
    {
        set
        {
            _gameRound = value;
            if (onRoundUpdated != null)
                onRoundUpdated.Invoke();

        }
        get { return _gameRound; }
    }
    public static string currentTurnStr
    {
        get { return (_currentTurn+1).ToString(); }
    }
    public static string gameRoundStr
    {
        get { return _gameRound.ToString(); }
    }
    public static string totalBetOfRoundStr
    {
        get { return _totalBetOfRound.ToString(); }
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
    public static List<CardData> dealerCards
    {
        set { _dealerCards = value; }
        get { return _dealerCards; }
    }
    public static List<PlayerData> players
    {
        set { _players = value; }
        get { return _players; }
    }
    public static List<PlayerData> foldedPlayers
    {
        set { _foldedPlayers = value; }
        get { return _foldedPlayers; }
    }
    public static GameController gameController
    {
        set { _gameController = value; }
        get { return _gameController; }
    }
    public static UIDisplay uIDisplay
    {
        set { _uIDisplay = value; }
        get { return _uIDisplay; }
    }


}
