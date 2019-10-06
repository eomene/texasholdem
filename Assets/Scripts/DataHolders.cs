using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Holds all data in the game
public static class DataHolders 
{
    private static int _startCash = 1000;
    private static int _currentBet = 0;
    private static int _currentTurn = 0;
    private static float _cardFlySpeed = 1f;
    private static float _cardFlipSpeed = 0.25f;
    private static float _delayBetweenPlayerCreation = .6f;
    private static GameObject _flyingCard;
    private static GameObject _chip;
    private static GameObject _control;
    private static Transform _mainCanvas;
    private static Transform _chipPositionOnBoard;
    private static List<int> _currentPlayers = new List<int>();
    private static GameController _gameController;

    public static int startCash
    {
        set { _startCash = value; }
        get { return _startCash; }
    }
    public static int currentBet
    {
        set { _currentBet = value; }
        get { return _currentBet; }
    }
    public static int currentTurn
    {
        set { _currentTurn = value; }
        get { return _currentTurn; }
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
    public static List<int> currentPlayers
    {
        set { _currentPlayers = value; }
        get { return _currentPlayers; }
    }
    public static GameController gameController
    {
        set { _gameController = value; }
        get { return _gameController; }
    }
}
