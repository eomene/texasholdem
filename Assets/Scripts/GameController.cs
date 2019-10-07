using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

        player = Resources.Load<GameObject>("Player");
        playerIcons = Resources.LoadAll<Sprite>("PlayerIcons/icons");

        DataHolders.gameController = this;
        DataHolders.flyingCard = Resources.Load<GameObject>("FlyingCard");
        DataHolders.chip = Resources.Load<GameObject>("Chip");
        DataHolders.mainCanvas = Canvas;
        DataHolders.chipPositionOnBoard = chipPositionOnBoard;
        DataHolders.controls = Resources.Load<GameObject>("Controls");
        GameObject UIObject = Resources.Load<GameObject>("UIDisplay");
        GameObject ui = Instantiate(UIObject, Canvas);
        DataHolders.uIDisplay = ui.GetComponent<UIDisplay>();
        DataHolders.currentTurn = 0;
        DataHolders.totalBetOfRound = 0;
        DataHolders.gameRound = 0;
        DataHolders.dealerPosition = startFlyPosition;


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
            //add the player to the list of players so we can use it later for gameplay in data holder
            DataHolders.players.Add(playerData);
            //add players to the array to go through it
            //DataHolders.currentPlayers.Add(i);
            //delay a bit so all players do not get cards at the same time
            yield return new WaitForSeconds(DataHolders.delayBetweenPlayerCreation);

        
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

    public IEnumerator FirstPlay()
    {
       // MoveCardsToTable(Players[0].cards);
        yield return new WaitForSeconds(DataHolders.delaySpeed);
        //bet 20 for first player
        DataHolders.players[DataHolders.currentTurn].Bet(20);
    }
    public IEnumerator Next(int current)
    {
        yield return new WaitForSeconds(DataHolders.delaySpeed);
        if ((current) < DataHolders.players.Count )
        {
            DataHolders.currentTurn = current;
            DataHolders.players[DataHolders.currentTurn].setToCurrent();
        }
        else
        {
            DataHolders.gameRound++;
            if (DataHolders.gameRound == 1)
            {
                //List<CardData> dealercards = new List<CardData>();
                //add three of the last cards to the stack of card decks
                DataHolders.dealerCards.Add(deck.Pop());
                DataHolders.dealerCards.Add(deck.Pop());
                DataHolders.dealerCards.Add(deck.Pop());
                MoveCardsToTable(DataHolders.dealerCards);
            }
            else if (DataHolders.gameRound == 2)
            {
                //List<CardData> dealercards = new List<CardData>();
                //add one of the last cards to the stack of card decks
                DataHolders.dealerCards.Add(deck.Pop());
                MoveCardsToTable(DataHolders.dealerCards);
            }
            else if (DataHolders.gameRound == 3)
            {
                // List<CardData> dealercards = new List<CardData>();
                //add one of the last cards to the stack of card decks
                DataHolders.dealerCards.Add(deck.Pop());
                MoveCardsToTable(DataHolders.dealerCards);
            }
            else if (DataHolders.gameRound == 4)
            {
                //end game logic
            }
            yield return new WaitForSeconds(DataHolders.delaySpeed);
            DataHolders.currentTurn = 0;
            DataHolders.players[DataHolders.currentTurn].setToCurrent();
        }

    }
    public void MoveCardsToTable(List<CardData> playerCards)
    {
        for (int i = 0; i < playerCards.Count; i++)
        {
            if (DataHolders.uIDisplay.centerCards.Count >= playerCards.Count)
            {
                if (!DataHolders.uIDisplay.centerCards[i].isFilled)
                {
                    DataHolders.uIDisplay.centerCards[i].isFilled = true;

                    DataHolders.uIDisplay.centerCards[i].img.sprite = playerCards[i].front;
                    //create a dummy card to fly into the screen
                    GameObject dummyCard = Instantiate(DataHolders.flyingCard, startFlyPosition.position, Quaternion.identity, Canvas);
                    //assign the real card
                    GameObject playercard = DataHolders.uIDisplay.centerCards[i].card;

                    //move dummy card to the real card location
                    dummyCard.transform.DOMove(playercard.transform.position, DataHolders.delaySpeed).OnComplete(() =>
                    {
                    //if real player flip card

                    //when dummy card is at the real card location scale the x to zero, to give the illusion of flipping
                    dummyCard.transform.DOScaleX(0, DataHolders.cardFlipSpeed).OnComplete(() =>
                            {
                                playercard.SetActive(true);
                            });

                    }).SetEase(Ease.Linear);//set ease type for movement
                }
            }
        }
    }
    //public void Bet()
    //{
    //    Players[0].Bet(20);
    //}
}
