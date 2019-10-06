using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform table;
    public Transform startFlyPosition;
    public Transform Canvas;
    public Transform chipPositionOnBoard;
    public Stack<CardData> deck = new Stack<CardData>();
    List<Transform> playerPositions = new List<Transform>();
    public List<PlayerData> Players = new List<PlayerData>();
    String[] randomNames = new string[] { "Jude", "Fred","Emma","Joe","Chris","Jerry" };
    Sprite[] playerIcons;
    GameObject card;
    GameObject player;
    //int currentTurn;
    //List<int> currentPlayers = new List<int>();


    void Awake()
    {
        Init();
        CreateDeck();
        Shuffle();
        StartCoroutine(CreatePlayers());
    }
    void Init()
    {
        //set some initial variables
        DataHolders.gameController = this;
        player = Resources.Load<GameObject>("Player");
        playerIcons = Resources.LoadAll<Sprite>("PlayerIcons/icons");
        DataHolders.flyingCard = Resources.Load<GameObject>("FlyingCard");
        DataHolders.chip = Resources.Load<GameObject>("Chip");
        DataHolders.mainCanvas = Canvas;
        DataHolders.chipPositionOnBoard = chipPositionOnBoard;
        DataHolders.controls = Resources.Load<GameObject>("Controls");
        foreach (Transform tr in table)
            playerPositions.Add(tr);
    }

    public IEnumerator CreatePlayers()
    {
        //loop through all the positions we currently have so players can be created for those positions
        //game currently has maximum of 6(wasnt told to limit or increase this//code can always be tweeked to allow more)
        for (int i = 0; i < playerPositions.Count; i++)
        {
            //create a new player gameobject in one of the positions already set in the scene
            GameObject newPlayerGameObject = Instantiate(player, playerPositions[i]);
            //make sure its in the centre
            newPlayerGameObject.transform.localPosition = Vector3.zero;
            //get the player script attached to it
            Player newPlayer = newPlayerGameObject.GetComponent<Player>();
            //create a new list of player cards
            List<CardData> playerCards = new List<CardData>();
            //add two of the last cards to the stack of card decks
            playerCards.Add(deck.Pop());
            playerCards.Add(deck.Pop());
            //create a new player data from the class to store all the variables we need
            PlayerData playerData = new PlayerData(playerCards, DataHolders.startCash, 0, playerIcons[i], randomNames[i], newPlayerGameObject);
            if (i == 2)
                playerData.isRealPlayer = true;
            //add the data to the player script attached to the player prefab, also pass in the position the cards will fly from
            newPlayer.UpdatePlayerData(playerData, startFlyPosition);
        
            playerData.playerID = i;
            //add the player to the list of players so we can use it later for gameplay
            Players.Add(playerData);
            //add players to the array to go through it
            DataHolders.currentPlayers.Add(i);
            //delay a bit so all players do not get cards at the same time
            yield return new WaitForSeconds(DataHolders.delayBetweenPlayerCreation);
            //bet for the first two players just like in the real game
            if (i == playerPositions.Count-1)
                StartCoroutine(FirstPlay());
        
        }
    }

    private void Shuffle()
    {
        //shuffle deck of cards
        deck.Shuffle();
    }

    void CreateDeck()
    {
        //Create card deck
        //get the individual sprites, not sure how i will get the art yet(temp)
        //loaded fro resources, but asset bundles can also be used
        Sprite[] diamonds = Resources.LoadAll<Sprite>("Cards/diamonds");
        Sprite[] clubs = Resources.LoadAll<Sprite>("Cards/clubs");
        Sprite[] hearts = Resources.LoadAll<Sprite>("Cards/hearts");
        Sprite[] spades = Resources.LoadAll<Sprite>("Cards/spades");
        Sprite back = Resources.Load<Sprite>("Cards/back");
        card = Resources.Load<GameObject>("Card");
        CardData cardObject = null;
        //create a temp enum for the type of card
        GameEnums.CardType cardtype = GameEnums.CardType.clubs;
        GameObject newCardGameObject = null;
        //create a parent for all the cards
        GameObject parent = new GameObject("Card Deck");

        //create for each type of card(this can be simplified based on how assets are given
        for (int i = 0; i < diamonds.Length; i++)
        {
            //set the type of card
            cardtype = GameEnums.CardType.diamonds;
            //create it and assign the parent card to it
            newCardGameObject = Instantiate(card, parent.transform);
            //get the card script attached so we can set the variables associated
            Card newCard = newCardGameObject.GetComponent<Card>();
            //create a card data to hold data for the card
            cardObject = new CardData(back, diamonds[i], cardtype, i + 1, newCardGameObject);
            //update the card script with card data
            newCard.UpdateCardObject(cardObject);
            //add to the deck of cards(actually a stack :) 
            deck.Push(cardObject);
        }
        for (int i = 0; i < clubs.Length; i++)
        {
            cardtype = GameEnums.CardType.clubs;
            newCardGameObject = Instantiate(card, parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            cardObject = new CardData(back, clubs[i], cardtype, i + 1, newCardGameObject);
            newCard.UpdateCardObject(cardObject);
            deck.Push(cardObject);
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            cardtype = GameEnums.CardType.hearts;
            newCardGameObject = Instantiate(card,parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            cardObject = new CardData(back, hearts[i], cardtype, i + 1, newCardGameObject);
            newCard.UpdateCardObject(cardObject);
            deck.Push(cardObject);
        }

        for (int i = 0; i < spades.Length; i++)
        {
            cardtype = GameEnums.CardType.spades;
            newCardGameObject = Instantiate(card, parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            cardObject = new CardData(back, spades[i], cardtype, i + 1, newCardGameObject);
            newCard.UpdateCardObject(cardObject);
            deck.Push(cardObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FirstPlay()
    {
        yield return new WaitForSeconds(DataHolders.cardFlySpeed);
        //bet 20 for first player
        Players[DataHolders.currentTurn].Bet(20);
        //DataHolders.currentTurn++;
        //yield return new WaitForSeconds(DataHolders.cardFlySpeed);
        ////double prev bet for second player at start of game
        //Players[DataHolders.currentTurn].Bet(20 * 2);
    }
    public IEnumerator Next(int current)
    {
        yield return new WaitForSeconds(DataHolders.cardFlySpeed);
        
        if ((DataHolders.currentTurn + 1) < DataHolders.currentPlayers.Count - 1)
        {
            DataHolders.currentTurn++;
            Players[DataHolders.currentTurn].setToCurrent();
        }
        else
        {
            DataHolders.currentTurn = 0;
            Players[DataHolders.currentTurn].setToCurrent();
        }
    }
    public void Bet()
    {
        Players[0].Bet(20);
    }
}
